namespace BasicArchitectureTemplate.DataAccess.Base
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BasicArchitectureTemplate.Models.Base;
    using Microsoft.EntityFrameworkCore.Storage;

    /// <summary>
    /// Interface with the CRUD contracts
    /// </summary>
    /// <typeparam name="T">Model class where the CRUD operations will be executed</typeparam>
    /// <typeparam name="TId">Class Identificator type</typeparam>
    public interface IRepositoryWithTypedId<T, TId> where T : class, IEntityWithTypedId<TId>
    {
        /// <summary>
        /// Allows the Query actions
        /// </summary>
        /// <returns></returns>
        IQueryable<T> Query();
        /// <summary>
        /// Adds an element asynchronously
        /// </summary>
        /// <param name="Entity">Object to add</param>
        Task AddAsync(T Entity);
        void Add(T Entity);
        /// <summary>
        /// Updates an especific element
        /// </summary>
        /// <param name="Entity">Object to update</param>
        void Update(T Entity);
        /// <summary>
        /// Deletes an element
        /// </summary>
        /// <param name="Entity">Object to remove from the context</param>
        void Remove(T Entity);
        /// <summary>
        /// Deletes a list of elements
        /// </summary>
        /// <param name="Entities">Objects to remove from the context</param>
        void RemoveRange(IList<T> Entities);
        /// <summary>
        /// Save model changes asynchronously
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync();
        int SaveChanges();
        /// <summary>
        /// Begins the transaction
        /// </summary>
        /// <returns></returns>
        IDbContextTransaction BeginTransaction();
    }
}
