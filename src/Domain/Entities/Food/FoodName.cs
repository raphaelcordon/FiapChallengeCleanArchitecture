namespace Domain.Entities.Food;

public class FoodName
{
    private string _foodName;

    public FoodName(string name)
    {
        Name = name;
    }

    public string Name
    {
        get => _foodName;
        set
        {
            if (value == null) throw new ArgumentNullException(nameof(value), "Name cannot be null ref: FoodName");

            if (value.Length < 2) throw new FormatException("Food name should have at least two characters");

            _foodName = value;
        }
    }
}