using Application.Features.ProductPrices.Commands.CreateProductPrice;
using Application.Features.ProductPrices.Commands.UpdateProductPrice;
using Application.Features.ProductPrices.Commands.DeleteProductPrice;
using Application.Features.ProductPrices.Queries.GetAllProductPrices;
using Application.Features.ProductPrices.Queries.GetProductPriceById;
using Application.Features.ProductPrices.Responses;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductPriceController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductPriceController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<Result<IEnumerable<GetAllProductPricesResponse>>>> Get([FromQuery] int? productSizeId)
    {
        var query = new GetAllProductPricesQuery(productSizeId);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Result<GetProductPriceByIdResponse>>> GetById(int id)
    {
        var query = new GetProductPriceByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Result<CreateProductPriceResponse>>> Post([FromBody] CreateProductPriceCommand command)
    {
        var result = await _mediator.Send(command);
        if (result.IsSuccess)
        {
            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);
        }
        return BadRequest(result);
    }

    [HttpPut]
    public async Task<ActionResult<Result<UpdateProductPriceResponse>>> Put([FromBody] UpdateProductPriceCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteProductPriceCommand(id);
        var result = await _mediator.Send(command);

        if (!result.IsSuccess) 
            return NotFound(result);
        
        return NoContent();
    }
}