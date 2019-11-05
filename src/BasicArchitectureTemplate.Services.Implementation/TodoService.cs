namespace BasicArchitectureTemplate.Services.Implementation
{
    using BasicArchitectureTemplate.DataAccess.Base;
    using BasicArchitectureTemplate.Models;
    using BasicArchitectureTemplate.Services.Contracts;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class TodoService : ITodoService
    {
        private readonly IRepository<TodoItem, int> _todoRepository;
        public TodoService(IRepository<TodoItem, int> todoRepository)
        {
            this._todoRepository = todoRepository;
        }

        public async Task<TodoItem> Create(TodoItem item)
        {
            _todoRepository.Add(item);
            await _todoRepository.SaveChangesAsync();
            return item;
        }

        public async Task<IList<TodoItem>> GetAll()
        {
            var elements = _todoRepository.Query();
            return await elements.ToListAsync();
        }
    }
}
