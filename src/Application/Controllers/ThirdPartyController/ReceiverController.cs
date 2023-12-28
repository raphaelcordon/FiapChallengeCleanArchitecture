using Application.Common;
using Application.Dtos.ThirdPartyDtos;
using Application.Interfaces.ThirdParty;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers.ThirdPartyRegister;

[ApiController]
[Route("api/v1/[controller]")]
public class ReceiverController : ControllerBase
{
    private readonly IReceiverService _receiverService;

    public ReceiverController(IReceiverService receiverService)
    {
        _receiverService = receiverService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(ReceiverRequestDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _receiverService.Insert(dto);
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

            var result = _receiverService.GetAll();
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

            var result = await _receiverService.GetById(id);

            return Ok(result);
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update(Guid id, ReceiverRequestDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var result = await _receiverService.Edit(id, dto);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _receiverService.Delete(id);
            return NoContent();
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}