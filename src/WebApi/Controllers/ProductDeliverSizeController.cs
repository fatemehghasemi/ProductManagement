using MediatR;
using Microsoft.AspNetCore.Mvc;
using Domain.Common;
using Application.Features.ProductDeliverSizes.Commands.CreateProductDeliverSize;
using Application.Features.ProductDeliverSizes.Queries.GetAllProductDeliverSizes;
using Application.Features.ProductDeliverSizes.Queries.GetProductDeliverSizeById;
using Application.Features.ProductDeliverSizes.Responses;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductDeliverSizeController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductDeliverSizeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<Result<IEnumerable<GetAllProductDeliverSizesResponse>>>> Get([FromQuery] int? productDeliverId, [FromQuery] int? productSizeId)
    {
        var query = new GetAllProductDeliverSizesQuery(productDeliverId, productSizeId);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Result<GetProductDeliverSizeByIdResponse>>> GetById(int id)
    {
        var query = new GetProductDeliverSizeByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Result<CreateProductDeliverSizeResponse>>> Post([FromBody] CreateProductDeliverSizeCommand command)
    {
        var result = await _mediator.Send(command);
        if (result.IsSuccess)
        {
            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);
        }
        return BadRequest(result);
    }
}