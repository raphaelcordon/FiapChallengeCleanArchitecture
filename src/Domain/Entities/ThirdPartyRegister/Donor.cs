namespace Domain.Entities.ThirdPartyRegister;

public class Donor : ThirdParty
{
    public void UpdateDetails(ThirdPartyName newName, bool iscompany)
    {
        Name = newName;
        IsCompany = iscompany;
    }
}