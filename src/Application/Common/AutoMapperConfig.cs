using Application.Dtos.FoodDtos;
using Application.Dtos.PackageDtos;
using Application.Dtos.ThirdPartyDtos;
using AutoMapper;
using Domain.Entities.Food;
using Domain.Entities.Package;
using Domain.Entities.ThirdPartyRegister;

namespace Application.Common;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        // DONOR
        CreateMap<Donor, DonorRequestDto>();
        CreateMap<DonorRequestDto, Donor>();
        
        CreateMap<Donor, DonorResponseDto>();
        CreateMap<DonorResponseDto, Donor>();
        
        // RECEIVER
        CreateMap<Receiver, ReceiverRequestDto>();
        CreateMap<ReceiverRequestDto, Receiver>();
        
        CreateMap<Receiver, ReceiverResponseDto>();
        CreateMap<ReceiverResponseDto, Receiver>();
        
        // FOOD
        CreateMap<Food, FoodRequestDto>();
        CreateMap<FoodRequestDto, Food>();
        
        CreateMap<Food, FoodResponseDto>();
        CreateMap<FoodResponseDto, Food>();
        
        // PACKAGE
        
        CreateMap<PackageReceived, PackageReceivedRequestDto>();
        CreateMap<PackageReceivedRequestDto, PackageReceived>();
        
        CreateMap<PackageReceived, PackageReceivedResponseDto>();
        CreateMap<PackageReceivedResponseDto, PackageReceived>();
        
        CreateMap<PackageSent, PackageSentRequestDto>();
        CreateMap<PackageSentRequestDto, PackageSent>();
        
        CreateMap<PackageSent, PackageSentResponseDto>();
        CreateMap<PackageSentResponseDto, PackageSent>();
    }
}