namespace BasicArchitectureTemplate.DataAccess.Base
{
    using BasicArchitectureTemplate.Models.Base;

    public interface IRepository<T, TId> : IRepositoryWithTypedId<T, TId>
        where T : class, IEntityWithTypedId<TId>
    {
    }
}
