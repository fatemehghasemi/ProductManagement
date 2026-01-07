using MediatR;
using Microsoft.AspNetCore.Mvc;
using Domain.Common;
using Application.Features.ProductAdtTypes.Commands.CreateProductAdtType;
using Application.Features.ProductAdtTypes.Queries.GetAllProductAdtTypes;
using Application.Features.ProductAdtTypes.Queries.GetProductAdtTypeById;
using Application.Features.ProductAdtTypes.Responses;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductAdtTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductAdtTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<Result<IEnumerable<GetAllProductAdtTypesResponse>>>> Get([FromQuery] int? productAdtId)
    {
        var query = new GetAllProductAdtTypesQuery(productAdtId);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Result<GetProductAdtTypeByIdResponse>>> GetById(int id)
    {
        var query = new GetProductAdtTypeByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Result<CreateProductAdtTypeResponse>>> Post([FromBody] CreateProductAdtTypeCommand command)
    {
        var result = await _mediator.Send(command);
        if (result.IsSuccess)
        {
            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);
        }
        return BadRequest(result);
    }
}