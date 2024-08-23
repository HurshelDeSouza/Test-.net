using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagerApi.Controllers;
using TaskManagerApi.Data;
using TaskManagerApi.Models;
using Xunit;

public class TasksControllerTests
{
    private readonly TasksController _controller;
    private readonly TaskContext _context;

    public TasksControllerTests()
    {
        var options = new DbContextOptionsBuilder<TaskContext>()
            .UseInMemoryDatabase(databaseName: "TaskDatabase")
        .Options;

        _context = new TaskContext(options);
        _controller = new TasksController(_context);
    }

    [Fact]
    public async Task PostTask_ShouldCreateTask()
    {
        // Arrange
        var newTask = new TaskItem { Title = "Test Task", Description = "Test Description" };

        // Act
        var result = await _controller.PostTask(newTask);

        // Assert
        var actionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
        var returnValue = Assert.IsType<TaskItem>(actionResult.Value);
        Assert.Equal("Test Task", returnValue.Title);
    }
}
