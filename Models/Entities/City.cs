using System.ComponentModel.DataAnnotations.Schema;

namespace Little_Conqueror.Models.Entities;

public class City : BaseEntity
{
    public string Name { get; set; }
    public string Country { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public int? Population { get; set; }
    [Column(TypeName = "jsonb")]
    public string Geojson { get; set; }
    public Player? Player { get; set; }
}