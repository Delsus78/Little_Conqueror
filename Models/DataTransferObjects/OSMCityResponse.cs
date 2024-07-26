namespace Little_Conqueror.Models.DataTransferObjects;

public record Address(string? City, string? State, string? Country);

public record Extratags(int? Population);

public record OSMCityResponse(
    int PlaceId, double? Lat, double? Lon, double? Importance, string Name,
    string? DisplayName, Address? Address, List<double> Boundingbox, Extratags? Extratags, Geojson? Geojson);

public record OSMCityRequest(float Latitude, float Longitude, bool ExtraTags);