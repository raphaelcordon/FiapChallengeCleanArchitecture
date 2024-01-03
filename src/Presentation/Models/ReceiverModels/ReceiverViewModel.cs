using Domain.Entities.ThirdPartyRegister;

namespace Presentation.Models.ReceiverModels;

public class ReceiverViewModel
{
    public ThirdPartyName? Name { get; set; }
    public bool IsCompany { get; set; }
}