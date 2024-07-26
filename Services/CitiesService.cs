using Little_Conqueror.Models.DataTransferObjects;

namespace Little_Conqueror.Services;

public interface ICitiesService
{
    Task<CityResponseDto> GetCity(CityRequestDto cityRequestDto);
}

public class CitiesService(INominatimOSMService nominatimOsmService) : ICitiesService
{
    public async Task<CityResponseDto> GetCity(CityRequestDto cityRequestDto)
    {
        var osmCityResponse = await 
            nominatimOsmService.GetCity(
                new OSMCityRequest(cityRequestDto.Latitude, cityRequestDto.Longitude, true));
        
        return new CityResponseDto(
            osmCityResponse.PlaceId,
            osmCityResponse.Name, 
            osmCityResponse.Extratags?.Population, 
            osmCityResponse.Lat, 
            osmCityResponse.Lon,
            osmCityResponse.Address?.Country,
            osmCityResponse.Geojson);
    }
}