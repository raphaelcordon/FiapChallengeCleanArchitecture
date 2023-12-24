namespace Application.Common;

public class FoodExpirationDateValidator
{
    public static bool IsDateExpired(DateOnly foodDate)
    {
        DateOnly today = DateOnly.FromDateTime(DateTime.Now);
        
        return foodDate <= today;
    }
}