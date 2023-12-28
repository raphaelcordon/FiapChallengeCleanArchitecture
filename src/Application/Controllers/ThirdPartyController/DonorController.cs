using Application.Common;
using Application.Dtos.ThirdPartyDtos;
using Application.Interfaces.ThirdParty;
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
    public async Task<IActionResult> Create(DonorRequestDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _donorService.Insert(dto);
            return Ok(result);
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _donorService.GetAll();
            return Ok(result);
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _donorService.GetById(id);

            return Ok(result);
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update(Guid id, DonorRequestDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var result = await _donorService.Edit(id, dto);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _donorService.Delete(id);
            return NoContent();
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}