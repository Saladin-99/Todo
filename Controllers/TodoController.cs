using Microsoft.AspNetCore.Mvc;
using Todo.Models;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly TodoContext _context;

    public TodoController(TodoContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTodoItem(TodoItem todoItem)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.TodoItems.Add(todoItem);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(CreateTodoItem), new { id = todoItem.Id }, todoItem);
    }

    // Additional methods for other CRUD operations could be added here
}
