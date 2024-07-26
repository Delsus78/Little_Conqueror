namespace Little_Conqueror.Models.DataTransferObjects;

public record Geojson(string Type, List<List<List<double>>> Coordinates);