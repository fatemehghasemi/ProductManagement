namespace Application.Features.ProductDelivers.Responses;

public class UpdateProductDeliverResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int ProductId { get; set; }
    public int DeliverId { get; set; }
    public bool Required { get; set; }
    public bool IsJeld { get; set; }
    public bool IsCustomCirculation { get; set; }
    public bool IsCombinedDeliver { get; set; }
    public int? Weight { get; set; }
}