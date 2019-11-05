namespace BasicArchitectureTemplate.DataAccess
{
    using BasicArchitectureTemplate.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;

    public class BasicArchitectureTemplateDbContext : DbContext
    {
        public DbSet<TodoItem> TodoItem { get; set; }

        public BasicArchitectureTemplateDbContext()
        {

        }

        public BasicArchitectureTemplateDbContext(DbContextOptions<BasicArchitectureTemplateDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Avoid pluralization
            foreach (IMutableEntityType entityType in builder.Model.GetEntityTypes())
            {
                entityType.SetTableName(entityType.DisplayName());
            }
        }
    }
}