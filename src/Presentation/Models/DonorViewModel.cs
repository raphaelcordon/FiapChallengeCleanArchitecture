using Domain.Entities.ThirdPartyRegister;

namespace Presentation.Models;

public class DonorViewModel
{
    public ThirdPartyName Name { get; set; }
    public bool IsCompany { get; set; }
}