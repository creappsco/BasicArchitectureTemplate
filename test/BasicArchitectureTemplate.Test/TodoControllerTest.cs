using BasicArchitectureTemplate.DataAccess;
using BasicArchitectureTemplate.DataAccess.Base;
using BasicArchitectureTemplate.Models;
using BasicArchitectureTemplate.Services.Implementation;
using BasicArchitectureTemplate.Test.Utilities;
using BasicArchitectureTemplate.WebAPI.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace BasicArchitectureTemplate.Test
{
    public class TodoControllerTest
    {
        [Fact]
        public async void Get_AllTodoItems()
        {
            // Arrange
            var entities = new List<TodoItem>
            {
                new TodoItem { Id = 1, Name = "Test 1" },
                new TodoItem { Id = 2, Name = "Test 2" },
                new TodoItem { Id = 3, Name = "Test 3" }
            };
            var context = new Mock<BasicArchitectureTemplateDbContext>();
            var dbSetMock = ServiceTestsHelper.GetMockDbSet<TodoItem>(entities);
            context.Setup(x => x.Set<TodoItem>()).Returns(dbSetMock.Object);
            var repositoryMock = new Mock<IRepository<TodoItem, int>>();
            repositoryMock.Setup(x => x.Query()).Returns((IQueryable<TodoItem>)dbSetMock.Object);
            var service = new TodoService(repositoryMock.Object);

            var controller = new TodoController(new NullLogger<TodoController>(), service);
            // Act
            var result = await controller.Get();
            //Assert
            var model = Assert.IsType<List<TodoItem>>(result);
            Assert.Equal(3, model.Count());
        }
    }
}
