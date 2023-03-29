using AutoMapper;
using ProTips.Business.Dtos;
using ProTips.Entity.Models;

namespace ProTips.Business.Configuration;

public class CustomDtoMapper : Profile
{
    public CustomDtoMapper()
    {
        CreateMap<TeamDto, Team>()
            .ReverseMap();

        CreateMap<CountryDto, Country>()
            .ReverseMap();
        
        CreateMap<LeagueDto, League>()
            .ReverseMap();
    }
}