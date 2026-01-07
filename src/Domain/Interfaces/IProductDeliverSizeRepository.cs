using Domain.Entities;

namespace Domain.Interfaces;

public interface IProductDeliverSizeRepository : IBaseRepository<ProductDeliverSize, int>
{
    Task<IEnumerable<ProductDeliverSize>> GetByProductSizeIdAsync(int productSizeId);
    Task<IEnumerable<ProductDeliverSize>> GetByProductDeliverIdAsync(int productDeliverId);
}