namespace RTraiding.Application.Domains.Entities;

public class Tick
{
    public int Id { get; set; }
    public decimal Price { get; set; }
    public decimal Volume { get; set; }
    public long Milliseconds { get; set; }
    public DateTime DateTime { get; set; }
    public string Symbol { get; set; }
}