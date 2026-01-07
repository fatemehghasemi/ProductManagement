using Application.Features.Products.Commands.CreateProduct;
using Application.Features.Products.Commands.UpdateProduct;
using Application.Features.Products.Commands.DeleteProduct;
using Application.Features.Products.Commands.CalculateProductPrice;
using Application.Features.Products.Queries.GetAllProducts;
using Application.Features.Products.Queries.GetProductById;
using Application.Features.Products.Responses;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<Result<IEnumerable<GetAllProductsResponse>>>> Get([FromQuery] int? productGroupId)
    {
        var query = new GetAllProductsQuery(productGroupId);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Result<GetProductByIdResponse>>> GetById(int id)
    {
        var query = new GetProductByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Result<CreateProductResponse>>> Post([FromBody] CreateProductCommand command)
    {
        var result = await _mediator.Send(command);
        if (result.IsSuccess)
        {
            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);
        }
        return BadRequest(result);
    }

    [HttpPost("{id}/calculate-price")]
    public async Task<ActionResult<Result<CalculateProductPriceResponse>>> CalculatePrice(
        int id, 
        [FromBody] CalculateProductPriceRequest request)
    {
        var command = new CalculateProductPriceCommand(
            id,
            request.ProductSizeId,
            request.ProductMaterialId,
            request.ProductPrintKindId,
            request.Circulation,
            request.PageCount,
            request.CopyCount,
            request.IsDoubleSided,
            request.PreferredStrategy
        );

        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<Result<UpdateProductResponse>>> Put([FromBody] UpdateProductCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteProductCommand(id);
        var result = await _mediator.Send(command);

        if (!result.IsSuccess) 
            return NotFound(result);
        
        return NoContent();
    }
}

/// <summary>
/// Request model for price calculation
/// </summary>
public class CalculateProductPriceRequest
{
    public int? ProductSizeId { get; set; }
    public int? ProductMaterialId { get; set; }
    public int? ProductPrintKindId { get; set; }
    public int Circulation { get; set; } = 1000;
    public int PageCount { get; set; } = 1;
    public int CopyCount { get; set; } = 1;
    public bool IsDoubleSided { get; set; } = false;
    public string? PreferredStrategy { get; set; }
}