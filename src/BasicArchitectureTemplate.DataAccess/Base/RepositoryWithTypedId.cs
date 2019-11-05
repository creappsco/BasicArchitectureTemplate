using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicArchitectureTemplate.Models.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace  BasicArchitectureTemplate.DataAccess.Base
{
    public class RepositoryWithTypedId<T, TId> : IRepositoryWithTypedId<T, TId> where T : class, IEntityWithTypedId<TId>
    {
        /// <summary>
        /// Database context
        /// </summary>
        protected DbContext Context;
        /// <summary>
        /// T Data in database
        /// </summary>
        protected DbSet<T> DbSet;

        /// <summary>
        /// Builds the object with the specified context
        /// </summary>
        /// <param name="context">Database context</param>
        public RepositoryWithTypedId(DbContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }

        /// <summary>
        /// Adds an element to the Db
        /// </summary>
        /// <param name="Entity">Object to add</param>
        public void Add(T Entity)=>
            DbSet.Add(Entity);

        /// <summary>
        /// Adds an element to the Db Asynchronously
        /// </summary>
        /// <param name="Entity">Object to add</param>
        public async Task AddAsync(T Entity)=>
            await DbSet.AddAsync(Entity);

        /// <summary>
        /// Begins the Db transaction
        /// </summary>
        /// <returns></returns>
        public IDbContextTransaction BeginTransaction() =>
            Context.Database.BeginTransaction();

        /// <summary>
        /// Allows the Query operations
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> Query() =>
            DbSet;

        /// <summary>
        /// Removes an element from the Db
        /// </summary>
        /// <param name="Entity"></param>
        public void Remove(T Entity) =>
            DbSet.Remove(Entity);

        /// <summary>
        /// Removes a list of elements from the Db
        /// </summary>
        /// <param name="Entities"></param>
        public void RemoveRange(IList<T> Entities) =>
            DbSet.RemoveRange(Entities);

        /// <summary>
        /// Saves model changes
        /// </summary>
        /// <returns></returns>
        public int SaveChanges() =>
            Context.SaveChanges();

        /// <summary>
        /// Saves model changes Asynchronously
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveChangesAsync() =>
            await Context.SaveChangesAsync();

        /// <summary>
        /// Updates the given object
        /// </summary>
        /// <param name="Entity">Object to update</param>
        /// <returns></returns>
        public void Update(T Entity) =>
            DbSet.Update(Entity);
    }
}
