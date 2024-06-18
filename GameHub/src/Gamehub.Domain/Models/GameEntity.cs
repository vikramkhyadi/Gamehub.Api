namespace Gamehub.Domain.Models;

public class GameEntity
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int StockQuantity { get; set; }
}
