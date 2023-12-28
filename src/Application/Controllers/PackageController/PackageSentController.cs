using Application.Common;
using Application.Dtos.PackageDtos;
using Application.Interfaces.Package;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers.PackageController;

[ApiController]
[Route("api/v1/[controller]")]
public class PackageSentController : ControllerBase
{
    private readonly IPackageSentService _packageSentService;

    public PackageSentController(IPackageSentService packageSentService)
    {
        _packageSentService = packageSentService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(PackageSentRequestDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _packageSentService.Insert(dto);
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

            var result = _packageSentService.GetAll();
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

            var result = await _packageSentService.GetById(id);

            return Ok(result);
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update(Guid id, PackageSentRequestDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var result = await _packageSentService.Edit(id, dto);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _packageSentService.Delete(id);
            return NoContent();
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}