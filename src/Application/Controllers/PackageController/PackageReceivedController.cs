using Application.Common;
using Application.Dtos.PackageDtos;
using Application.Interfaces.Package;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers.PackageController;

[ApiController]
[Route("api/v1/[controller]")]
public class PackageReceivedController : ControllerBase
{
    private readonly IPackageReceivedService _packageReceivedService;

    public PackageReceivedController(IPackageReceivedService packageReceivedService)
    {
        _packageReceivedService = packageReceivedService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(PackageReceivedRequestDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _packageReceivedService.Insert(dto);
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

            var result = _packageReceivedService.GetAll();
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

            var result = await _packageReceivedService.GetById(id);

            return Ok(result);
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update(Guid id, PackageReceivedRequestDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var result = await _packageReceivedService.Edit(id, dto);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _packageReceivedService.Delete(id);
            return NoContent();
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}