using Domain.Enums.Food;

namespace Domain.Entities.Food;

public class Food : Base
{
    public Food(FoodName foodName, State state, bool isPerishable, FoodExpirationDate expirationDate)
    {
        FoodName = foodName;
        State = state;
        IsPerishable = isPerishable;
        ExpirationDate = expirationDate;
    }

    public FoodName FoodName { get; set; }
    public State State { get; set; }
    public bool IsPerishable { get; set; } = false;
    public FoodExpirationDate ExpirationDate { get; set; }
}

