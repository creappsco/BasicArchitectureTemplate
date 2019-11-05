namespace BasicArchitectureTemplate.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BasicArchitectureTemplate.Models;
    public interface ITodoService
    {
        Task<TodoItem> Create(TodoItem todo);
        Task<IList<TodoItem>> GetAll();
    }
}
