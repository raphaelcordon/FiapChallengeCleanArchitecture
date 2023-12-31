using Application.Dtos.FoodDtos;

namespace Application.Interfaces.Food;

public interface IFoodService
{
    Task<FoodResponseDto> Insert(FoodRequestDto dto);
    IEnumerable<FoodResponseDto> GetAll();
    Task<FoodResponseDto> GetById(Guid id);
    Task<FoodResponseDto> Edit(Guid id, FoodRequestDto dto);
    Task Delete(Guid id);
}