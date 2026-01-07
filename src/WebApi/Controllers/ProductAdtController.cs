using Application.Features.ProductAdts.Commands.CreateProductAdt;
using Application.Features.ProductAdts.Commands.UpdateProductAdt;
using Application.Features.ProductAdts.Commands.DeleteProductAdt;
using Application.Features.ProductAdts.Queries.GetAllProductAdts;
using Application.Features.ProductAdts.Queries.GetProductAdtById;
using Application.Features.ProductAdts.Responses;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductAdtController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductAdtController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<Result<IEnumerable<GetAllProductAdtsResponse>>>> Get([FromQuery] int? productId)
    {
        var query = new GetAllProductAdtsQuery(productId);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Result<GetProductAdtByIdResponse>>> GetById(int id)
    {
        var query = new GetProductAdtByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Result<CreateProductAdtResponse>>> Post([FromBody] CreateProductAdtCommand command)
    {
        var result = await _mediator.Send(command);
        if (result.IsSuccess)
        {
            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);
        }
        return BadRequest(result);
    }

    [HttpPut]
    public async Task<ActionResult<Result<UpdateProductAdtResponse>>> Put([FromBody] UpdateProductAdtCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteProductAdtCommand(id);
        var result = await _mediator.Send(command);

        if (!result.IsSuccess) 
            return NotFound(result);
        
        return NoContent();
    }
}