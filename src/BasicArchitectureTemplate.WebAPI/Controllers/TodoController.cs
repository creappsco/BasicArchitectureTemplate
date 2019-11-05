using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicArchitectureTemplate.Models;
using BasicArchitectureTemplate.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BasicArchitectureTemplate.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        private readonly ILogger<TodoController> _logger;

        public TodoController(ILogger<TodoController> logger, ITodoService todoService)
        {
            _logger = logger;
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<IEnumerable<TodoItem>> Get()
        {
            return await this._todoService.GetAll();
        }
    }
}
