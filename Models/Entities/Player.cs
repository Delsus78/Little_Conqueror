namespace Little_Conqueror.Models.Entities;

public class Player : BaseEntity
{
    public string Name { get; set; }
    
    public List<City> Cities { get; } = new();
}