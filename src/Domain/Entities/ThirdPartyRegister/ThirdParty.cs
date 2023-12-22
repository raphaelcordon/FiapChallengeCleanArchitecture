namespace Domain.Entities.ThirdPartyRegister;

public abstract class ThirdParty : Base
{
    public ThirdPartyName Name { get; set; }
    public bool IsCompany { get; set; }
}