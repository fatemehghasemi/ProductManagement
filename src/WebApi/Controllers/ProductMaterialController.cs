using Application.Features.ProductMaterials.Commands.CreateProductMaterial;
using Application.Features.ProductMaterials.Commands.UpdateProductMaterial;
using Application.Features.ProductMaterials.Commands.DeleteProductMaterial;
using Application.Features.ProductMaterials.Queries.GetAllProductMaterials;
using Application.Features.ProductMaterials.Queries.GetProductMaterialById;
using Application.Features.ProductMaterials.Responses;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductMaterialController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductMaterialController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<Result<IEnumerable<GetAllProductMaterialsResponse>>>> Get([FromQuery] int? productId)
    {
        var query = new GetAllProductMaterialsQuery(productId);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Result<GetProductMaterialByIdResponse>>> GetById(int id)
    {
        var query = new GetProductMaterialByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Result<CreateProductMaterialResponse>>> Post([FromBody] CreateProductMaterialCommand command)
    {
        var result = await _mediator.Send(command);
        if (result.IsSuccess)
        {
            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);
        }
        return BadRequest(result);
    }

    [HttpPut]
    public async Task<ActionResult<Result<UpdateProductMaterialResponse>>> Put([FromBody] UpdateProductMaterialCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteProductMaterialCommand(id);
        var result = await _mediator.Send(command);

        if (!result.IsSuccess) 
            return NotFound(result);
        
        return NoContent();
    }
}