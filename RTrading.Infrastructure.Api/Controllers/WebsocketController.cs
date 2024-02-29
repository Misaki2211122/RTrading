using System.ComponentModel;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RTraiding.Application.Domains.States;

namespace RTrading.Infrastructure.Api.Controllers;

[ApiController]
[DisplayName("Контроллер вебсокета")]
[Produces("application/json")]
[Route("/ws/")]
public class WebsocketController : ControllerBase
{
    private Guid idUser;
    private WebSocket webSocket;
    
    public WebsocketController()
    {
    }
    
    [HttpGet("subscribe")]
    public async Task Subscribe([FromQuery] Guid idUser)
    {
        try
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                this.idUser = idUser;
                webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                await Echo(HttpContext, webSocket);
            }
            else
            {
                HttpContext.Response.StatusCode = (int) HttpStatusCode.BadRequest;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private async Task Echo(HttpContext context, WebSocket webSocket)
    {
        try
        {
            var buffer = new byte[1024];
            WebSocketReceiveResult result =
                await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            var stringRecieve = GetStringFromByte(buffer);
            if (result.MessageType == WebSocketMessageType.Text)
            {
                if (stringRecieve.Contains("trade"))
                {
                    //TODO : проверки подписки итд по аккаунту
                    WsEvents.StrategyTradeEv += WsEventsOnStrategyTradeEv;
                    if (webSocket.State == WebSocketState.Open)
                        await webSocket.SendAsync(new ArraySegment<byte>(buffer, 0, result.Count), result.MessageType,
                            result.EndOfMessage, CancellationToken.None);
                }
            }

            result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            while (!result.CloseStatus.HasValue)
            {
                if (webSocket.State == WebSocketState.Open)
                    await webSocket.SendAsync(new ArraySegment<byte>(buffer, 0, result.Count), result.MessageType,
                        result.EndOfMessage, CancellationToken.None);

                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            }
        }
        catch (Exception e)
        {

        }
    }

    private async void WsEventsOnStrategyTradeEv(decimal price, string symbol, decimal level)
    {
        var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new
        {
            Price = price,
            Symbol = symbol,
            DateTime = DateTime.Now,
            Level = level
        }));
        
        if (webSocket.State == WebSocketState.Open)
            await webSocket.SendAsync(new ArraySegment<byte>(bytes, 0, bytes.Length),
                WebSocketMessageType.Text, true, CancellationToken.None);
    }


    private string GetStringFromByte(byte[] buffer)
         => System.Text.Encoding.UTF8.GetString(buffer);
}