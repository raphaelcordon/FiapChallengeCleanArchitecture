namespace Domain.Entities.Food;

public class FoodExpirationDate
{
    private DateTime _expirationDate;
    
    public FoodExpirationDate(DateTime expirationDate)
    {
        ExpirationDate = expirationDate;
    }

    public DateTime ExpirationDate
    {
        get => _expirationDate;
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value),"Date cannot be null. ref: FoodExpiration");
            }
            if (value <= DateTime.Today)
            {
                throw new FormatException("Food expiration cannot be accepted if it is due to expire");
            }

            _expirationDate = value;
        }
    }
}