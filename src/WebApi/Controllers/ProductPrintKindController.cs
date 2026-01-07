using MediatR;
using Microsoft.AspNetCore.Mvc;
using Domain.Common;
using Application.Features.ProductPrintKinds.Commands.CreateProductPrintKind;
using Application.Features.ProductPrintKinds.Queries.GetAllProductPrintKinds;
using Application.Features.ProductPrintKinds.Queries.GetProductPrintKindById;
using Application.Features.ProductPrintKinds.Responses;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductPrintKindController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductPrintKindController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<Result<IEnumerable<GetAllProductPrintKindsResponse>>>> Get([FromQuery] int? productId)
    {
        var query = new GetAllProductPrintKindsQuery(productId);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Result<GetProductPrintKindByIdResponse>>> GetById(int id)
    {
        var query = new GetProductPrintKindByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Result<CreateProductPrintKindResponse>>> Post([FromBody] CreateProductPrintKindCommand command)
    {
        var result = await _mediator.Send(command);
        if (result.IsSuccess)
        {
            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);
        }
        return BadRequest(result);
    }
}