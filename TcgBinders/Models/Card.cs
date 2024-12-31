namespace TcgBinders.Models;

public class Card
{
    public int id { get; set; }
    public string name { get; set; }
    public string rarity { get; set; }
    public string set_tag { get; set; }
    public int no_in_set { get; set; }
}