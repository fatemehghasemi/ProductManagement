using Application.Features.ProductDelivers.Commands.CreateProductDeliver;
using Application.Features.ProductDelivers.Commands.UpdateProductDeliver;
using Application.Features.ProductDelivers.Commands.DeleteProductDeliver;
using Application.Features.ProductDelivers.Queries.GetAllProductDelivers;
using Application.Features.ProductDelivers.Queries.GetProductDeliverById;
using Application.Features.ProductDelivers.Responses;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductDeliverController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductDeliverController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<Result<IEnumerable<GetAllProductDeliversResponse>>>> Get([FromQuery] int? productId)
    {
        var query = new GetAllProductDeliversQuery(productId);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Result<GetProductDeliverByIdResponse>>> GetById(int id)
    {
        var query = new GetProductDeliverByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Result<CreateProductDeliverResponse>>> Post([FromBody] CreateProductDeliverCommand command)
    {
        var result = await _mediator.Send(command);
        if (result.IsSuccess)
        {
            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);
        }
        return BadRequest(result);
    }

    [HttpPut]
    public async Task<ActionResult<Result<UpdateProductDeliverResponse>>> Put([FromBody] UpdateProductDeliverCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteProductDeliverCommand(id);
        var result = await _mediator.Send(command);

        if (!result.IsSuccess) 
            return NotFound(result);
        
        return NoContent();
    }
}