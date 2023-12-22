using Application.Dtos.ThirdParty;
using Application.Interfaces.ThirdParty;
using Domain.Entities.ThirdPartyRegister;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers.ThirdPartyRegister;

[ApiController]
[Route("api/v1/[controller]")]
public class DonorController : ControllerBase
{
    private readonly IDonorService _donorService;

    public DonorController(IDonorService donorService)
    {
        _donorService = donorService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateDonor(DonorRequestDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _donorService.Insert(dto);
        return Ok(result);
    }
}