using Little_Conqueror.Models.DataTransferObjects;
using Little_Conqueror.Services;
using Microsoft.AspNetCore.Mvc;

namespace Little_Conqueror.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CitiesController(ICitiesService citiesService) : ControllerBase
{
    [HttpGet]
    public Task<CityResponseDto> GetCity([FromQuery] CityRequestDto cityRequestDto)
    {
        var city = citiesService.GetCity(cityRequestDto);
        return city;
    }
}