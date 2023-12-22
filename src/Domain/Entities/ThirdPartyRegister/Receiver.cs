namespace Domain.Entities.ThirdPartyRegister;

public class Receiver : ThirdParty
{
    public void UpdateDetails(ThirdPartyName newName, bool iscompany)
    {
        Name = newName;
        IsCompany = iscompany;
    }
}