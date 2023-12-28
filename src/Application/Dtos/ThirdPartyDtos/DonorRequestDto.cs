using Domain.Entities.ThirdPartyRegister;

namespace Application.Dtos.ThirdPartyDtos;

public class DonorRequestDto
{
    public required ThirdPartyName Name { get; set; }
    public bool IsCompany { get; set; }
}