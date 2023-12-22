namespace Domain.Entities.ThirdPartyRegister;

public class ThirdPartyName
{
    public ThirdPartyName(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name),
            "Name cannot be null. ref: ThirdPartyName");
    }
    public string Name { get; }
}