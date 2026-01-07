using MediatR;
using Microsoft.AspNetCore.Mvc;
using Domain.Common;
using Application.Features.ProductAdtPrices.Commands.CreateProductAdtPrice;
using Application.Features.ProductAdtPrices.Queries.GetAllProductAdtPrices;
using Application.Features.ProductAdtPrices.Queries.GetProductAdtPriceById;
using Application.Features.ProductAdtPrices.Responses;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductAdtPriceController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductAdtPriceController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<Result<IEnumerable<GetAllProductAdtPricesResponse>>>> Get([FromQuery] int? productAdtId)
    {
        var query = new GetAllProductAdtPricesQuery(productAdtId);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Result<GetProductAdtPriceByIdResponse>>> GetById(int id)
    {
        var query = new GetProductAdtPriceByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Result<CreateProductAdtPriceResponse>>> Post([FromBody] CreateProductAdtPriceCommand command)
    {
        var result = await _mediator.Send(command);
        if (result.IsSuccess)
        {
            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);
        }
        return BadRequest(result);
    }
}