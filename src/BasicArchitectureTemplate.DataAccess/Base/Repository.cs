
namespace  BasicArchitectureTemplate.DataAccess.Base
{
    using BasicArchitectureTemplate.Models.Base;

    public class Repository<T, TId> : RepositoryWithTypedId<T, TId>, IRepository<T, TId>
        where T : class, IEntityWithTypedId<TId>
    {
        public Repository(BasicArchitectureTemplateDbContext context) : base(context)
        {

        }
    }
}
