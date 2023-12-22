using Domain.Entities.ThirdPartyRegister;

namespace Application.Dtos.ThirdParty;

public class ReceiverRequestDto
{
    public required ThirdPartyName Name { get; set; }
    public bool IsCompany { get; set; }
}