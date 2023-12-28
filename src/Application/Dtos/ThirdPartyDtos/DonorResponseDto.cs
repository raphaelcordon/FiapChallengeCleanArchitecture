using Domain.Entities.ThirdPartyRegister;

namespace Application.Dtos.ThirdPartyDtos;

public class DonorResponseDto
{
    public Guid Id { get; set; }
    public required ThirdPartyName Name { get; set; }
    public bool IsCompany { get; set; }
}