using AutoMapper;
using ProTips.Business.Dtos;
using ProTips.Entity.Models;

namespace ProTips.Business.Configuration;

public class CustomDtoMapper : Profile
{
    public CustomDtoMapper()
    {
        CreateMap<BetDto, Bet>()
            .ReverseMap();

        CreateMap<BetStrategyDto, BetStrategy>()
            .ReverseMap();

        CreateMap<CountryDto, Country>()
            .ReverseMap();

        CreateMap<CurrencyDto, Currency>()
            .ReverseMap();

        CreateMap<GameDto, Game>()
            .ReverseMap();

        CreateMap<LeagueDto, League>()
            .ReverseMap();

        CreateMap<LinkDto, Link>()
            .ReverseMap();

        CreateMap<PreLiveDto, PreLive>()
            .ReverseMap();

        CreateMap<ResultDto, Result>()
            .ForMember(x => x.HalfTimeGoalsHome, y => y.MapFrom(z => z.HalfTimeGols.Home))
            .ForMember(x => x.HalfTimeGoalsAway, y => y.MapFrom(z => z.HalfTimeGols.Away))
            .ForMember(x => x.FullTimeGoalsHome, y => y.MapFrom(z => z.FullTimeGols.Home))
            .ForMember(x => x.FullTimeGoalsAway, y => y.MapFrom(z => z.FullTimeGols.Away))
            .ReverseMap();
        
        CreateMap<TeamDto, Team>()
            .ReverseMap();

        CreateMap<TipDto, Tip>()
            .ReverseMap();

        CreateMap<UserDto, User>()
            .ReverseMap();

        CreateMap<User, UserAuthenticated>()
            .ReverseMap();
    }
}