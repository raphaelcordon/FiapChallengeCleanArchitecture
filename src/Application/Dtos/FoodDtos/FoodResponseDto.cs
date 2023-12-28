using Domain.Entities.Food;
using Domain.Enums.Food;

namespace Application.Dtos.FoodDtos;

public class FoodResponseDto
{
    public Guid Id { get; set; }
    public FoodName FoodName { get; set; }
    public State State { get; set; }
    public bool IsPerishable { get; set; }
    public DateOnly ExpirationDate { get; set; }
}