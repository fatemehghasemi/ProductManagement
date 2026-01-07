using Application.Features.ProductSizes.Commands.CreateProductSize;
using Application.Features.ProductSizes.Commands.UpdateProductSize;
using Application.Features.ProductSizes.Commands.DeleteProductSize;
using Application.Features.ProductSizes.Queries.GetAllProductSizes;
using Application.Features.ProductSizes.Queries.GetProductSizeById;
using Application.Features.ProductSizes.Responses;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductSizeController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductSizeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<Result<IEnumerable<GetAllProductSizesResponse>>>> Get([FromQuery] int? productId)
    {
        var query = new GetAllProductSizesQuery(productId);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Result<GetProductSizeByIdResponse>>> GetById(int id)
    {
        var query = new GetProductSizeByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Result<CreateProductSizeResponse>>> Post([FromBody] CreateProductSizeCommand command)
    {
        var result = await _mediator.Send(command);
        if (result.IsSuccess)
        {
            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);
        }
        return BadRequest(result);
    }

    [HttpPut]
    public async Task<ActionResult<Result<UpdateProductSizeResponse>>> Put([FromBody] UpdateProductSizeCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteProductSizeCommand(id);
        var result = await _mediator.Send(command);

        if (!result.IsSuccess) 
            return NotFound(result);
        
        return NoContent();
    }
}