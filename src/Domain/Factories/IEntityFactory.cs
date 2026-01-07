namespace Domain.Factories;

/// <summary>
/// Generic factory interface for creating domain entities
/// </summary>
/// <typeparam name="TEntity">The entity type to create</typeparam>
/// <typeparam name="TCreateModel">The model used for creation</typeparam>
public interface IEntityFactory<TEntity, in TCreateModel>
{
    TEntity Create(TCreateModel model);
    Task<TEntity> CreateAsync(TCreateModel model);
}