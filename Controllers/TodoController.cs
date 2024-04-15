using Microsoft.AspNetCore.Mvc;
using Todo.Models;
using Todo.Services;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly ITodoService _todoService;

    public TodoController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTodoItem(TodoItem todoItem)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdTodoItem = await _todoService.CreateTodoItem(todoItem);
        return CreatedAtAction(nameof(CreateTodoItem), new { id = createdTodoItem.Id }, createdTodoItem);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTodoItems()
    {
        var todoItems = await _todoService.GetAllTodoItems();
        return Ok(todoItems);
    }

    // Additional methods for other CRUD operations could be added here
}
