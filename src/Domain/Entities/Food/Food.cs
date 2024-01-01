using Domain.Enums.Food;

namespace Domain.Entities.Food;

public class Food : Base
{
    public Food(FoodName foodName, State state, bool isPerishable, DateOnly expirationDate)
    {
        FoodName = foodName;
        State = state;
        IsPerishable = isPerishable;
        ExpirationDate = expirationDate;
    }

    public FoodName FoodName { get; set; }
    public State State { get; set; }
    public bool IsPerishable { get; set; }
    public DateOnly ExpirationDate { get; set; }

    public void UpdateDetails(FoodName foodName, State state, bool isPerishable, DateOnly expirationDate)
    {
        FoodName = foodName;
        State = state;
        IsPerishable = isPerishable;
        ExpirationDate = expirationDate;
    }
}