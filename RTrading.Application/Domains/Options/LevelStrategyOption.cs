namespace RTraiding.Application.Domains.Options;

public class LevelStrategyOption
{
    public const string LevelStrategy = "LevelStrategyOption";
    public string WsUrl { get; set; }
    public string Url { get; set; }
    public string Symbol { get; set; }
    public decimal ScopePrice { get; set; }
    public bool IsStart { get; set; }
}