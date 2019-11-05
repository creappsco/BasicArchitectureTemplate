namespace BasicArchitectureTemplate.Models.Base
{
    public interface IEntityWithTypedId<TId>
    {
        TId Id { get; }
    }
}
