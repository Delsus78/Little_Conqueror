using System.Text.Json;
using Little_Conqueror.Exceptions;
using Little_Conqueror.Helpers.Extensions;
using Little_Conqueror.Helpers.JsonConverters;
using Little_Conqueror.Models.DataTransferObjects;

namespace Little_Conqueror.Services;


public interface INominatimOSMService
{
    Task<OSMCityResponse> GetCity(OSMCityRequest cityRequestDto);
}
public class NominatimOSMService(IHttpClientFactory httpClientFactory) : INominatimOSMService
{
    public async Task<OSMCityResponse> GetCity(OSMCityRequest cityRequestDto)
    {
        var httpClient = httpClientFactory.CreateClient("NominatimOSM");

        var urlparams = $"reverse?format=jsonv2&lat={cityRequestDto.Latitude.ToURIString()}&lon={cityRequestDto.Longitude.ToURIString()}&zoom=10&polygon_geojson=1";
        
        urlparams += cityRequestDto.ExtraTags ? "&extratags=1" : "";

        var response = await httpClient
            .GetAsync(urlparams);
        
        if (!response.IsSuccessStatusCode)
            throw new AppException("Error while fetching data from Nominatim OSM", (int) response.StatusCode);
        
        var content = await response.Content.ReadAsStringAsync();
        
        var jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters = {new StringOrNumberToDoubleConverter(), new StringToIntConverter()}
        };
        
        var city = JsonSerializer.Deserialize<OSMCityResponse>(content, jsonOptions);
        
        return city;
    }
}