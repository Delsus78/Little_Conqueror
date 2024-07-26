namespace Little_Conqueror.Models.DataTransferObjects;

public record CityRequestDto(float Latitude, float Longitude);

public record CityResponseDto(int Id, string Name, int? population, double? Latitude, double? Longitude, string? Country, Geojson? Geojson);