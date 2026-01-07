using MediatR;
using Microsoft.AspNetCore.Mvc;
using Domain.Common;
using Application.Features.ProductMaterialAttributes.Commands.CreateProductMaterialAttribute;
using Application.Features.ProductMaterialAttributes.Queries.GetAllProductMaterialAttributes;
using Application.Features.ProductMaterialAttributes.Queries.GetProductMaterialAttributeById;
using Application.Features.ProductMaterialAttributes.Responses;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductMaterialAttributeController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductMaterialAttributeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<Result<IEnumerable<GetAllProductMaterialAttributesResponse>>>> Get([FromQuery] int? productMaterialId)
    {
        var query = new GetAllProductMaterialAttributesQuery(productMaterialId);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Result<GetProductMaterialAttributeByIdResponse>>> GetById(int id)
    {
        var query = new GetProductMaterialAttributeByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Result<CreateProductMaterialAttributeResponse>>> Post([FromBody] CreateProductMaterialAttributeCommand command)
    {
        var result = await _mediator.Send(command);
        if (result.IsSuccess)
        {
            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);
        }
        return BadRequest(result);
    }
}