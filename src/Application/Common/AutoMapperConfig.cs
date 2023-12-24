using Application.Dtos.Food;
using Application.Dtos.ThirdParty;
using AutoMapper;
using Domain.Entities.Food;
using Domain.Entities.ThirdPartyRegister;

namespace Application.Common;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<Donor, DonorRequestDto>();
        CreateMap<DonorRequestDto, Donor>();
        
        CreateMap<Donor, DonorResponseDto>();
        CreateMap<DonorResponseDto, Donor>();
        
        CreateMap<Receiver, ReceiverRequestDto>();
        CreateMap<ReceiverRequestDto, Receiver>();
        
        CreateMap<Receiver, ReceiverResponseDto>();
        CreateMap<ReceiverResponseDto, Receiver>();
        
        CreateMap<Food, FoodRequestDto>();
        CreateMap<FoodRequestDto, Food>();
        
        CreateMap<Food, FoodResponseDto>();
        CreateMap<FoodResponseDto, Food>();
    }
}