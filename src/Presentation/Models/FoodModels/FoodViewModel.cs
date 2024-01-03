using Domain.Enums.Food;

namespace Presentation.Models.FoodModels;

public class FoodViewModel
{
    public string? FoodName { get; set; }
    public State State { get; set; }
    public bool IsPerishable { get; set; }
    public DateOnly ExpirationDate { get; set; }
}