using ECommerce.Application.Common.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DomainAttribute = ECommerce.Domain.Entities.Catalog.Attribute;

namespace ECommerce.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AttributeController(IAttributeService attributeService): ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetAttributeById(Guid id)
    {
        var attribute = await attributeService.GetAttributeByIdAsync(id);
        return Ok(attribute);
    }
    
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddAttribute(DomainAttribute attribute)
    {
        await attributeService.AddAsync(attribute);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteAttribute(Guid id)
    {
        await attributeService.DeleteAsync(id);
        return Ok();
    }
}