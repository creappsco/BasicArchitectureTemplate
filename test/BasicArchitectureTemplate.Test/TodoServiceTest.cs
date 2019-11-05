using System;
using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using BasicArchitectureTemplate.Models;
using BasicArchitectureTemplate.DataAccess;
using BasicArchitectureTemplate.Test.Utilities;
using BasicArchitectureTemplate.DataAccess.Base;
using BasicArchitectureTemplate.Services.Implementation;
using System.Threading.Tasks;

namespace BasicArchitectureTemplate.Test
{
    public class TodoServiceTest
    {
        [Fact]
        public async Task ShouldBy_Add_Todo()
        {
            // Arrange
            var testObject = new TodoItem { Id = 4, Name = "Test 3" };
            var entities = new List<TodoItem>
            {
                new TodoItem { Id = 1, Name = "Test 1" },
                new TodoItem { Id = 2, Name = "Test 2" },
                new TodoItem { Id = 3, Name = "Test 3" }
            };

            var context = new Mock<BasicArchitectureTemplateDbContext>();
            var dbSetMock = ServiceTestsHelper.GetMockDbSet<TodoItem>(entities);
            context.Setup(x => x.Set<TodoItem>()).Returns(dbSetMock.Object);
            var repository = new Repository<TodoItem, int>(context.Object);
            var service = new TodoService(repository);
            // Act
            await service.Create(testObject);
            var newData = repository.Query().FirstOrDefault(x => x.Id == 4);
            //Assert
            Assert.Equal(testObject, newData);
        }

        [Fact]
        public async Task ShouldBy_Get_TodoList()
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
            // Act
            var data = await service.GetAll();
            //Assert
            Assert.NotEmpty(data);
            Assert.Equal(3,data.Count);
        }
    }
}
