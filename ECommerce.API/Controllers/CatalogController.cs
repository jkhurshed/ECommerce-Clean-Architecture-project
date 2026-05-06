using ECommerce.Application.Common.Interfaces.Services;
using ECommerce.Application.Services.Catalog.Services;
using ECommerce.Domain.Entities.Catalog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DomainAttribute = ECommerce.Domain.Entities.Catalog.Attribute;

namespace ECommerce.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CatalogController(
    IAttributeService attributeService,
    IProductService productService
    ): ControllerBase
{
    [HttpGet("attribute/get/{id:guid}")]
    public async Task<IActionResult> GetAttributeById(Guid id)
    {
        var attribute = await attributeService.GetAttributeByIdAsync(id);
        return Ok(attribute);
    }
    
    [Authorize]
    [HttpPost("attribute/create")]
    public async Task<IActionResult> AddAttribute(DomainAttribute attribute)
    {
        await attributeService.AddAsync(attribute);
        return Ok();
    }

    [HttpDelete("attribute/delete/{id:guid}")]
    public async Task<ActionResult> DeleteAttribute(Guid id)
    {
        await attributeService.DeleteAsync(id);
        return Ok();
    }

    [Authorize]
    [HttpGet("product/get/{id:guid}")]
    public async Task<IActionResult> GetProductById(Guid id)
    {
        var product = await productService.GetProductByIdAsync(id);
        return Ok(product);
    }

    [Authorize]
    [HttpPost("product/create")]
    public async Task<IActionResult> AddProduct(Product product)
    {
        await productService.AddAsync(product);
        return Ok();
    }

    [Authorize]
    [HttpDelete("product/delete/{id:guid}")]
    public async Task<ActionResult> DeleteProduct(Guid id)
    {
        await productService.DeleteAsync(id);
        return Ok();
    }
}