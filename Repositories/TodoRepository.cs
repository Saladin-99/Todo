using Microsoft.EntityFrameworkCore;
using Todo.Models;

namespace Todo.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext _context;

        public TodoRepository(TodoContext context)
        {
            _context = context;
        }

        public async Task<TodoItem> CreateTodoItem(TodoItem todoItem)
        {
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();
            return todoItem;
        }

        public async Task<List<TodoItem>> GetAllTodoItems()
        {   
            var items = await _context.TodoItems.ToListAsync();
            return items;
        }

        // Other CRUD methods can be implemented here

        // Unit of Work functionality
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

    public interface ITodoRepository
    {
        Task<TodoItem> CreateTodoItem(TodoItem todoItem);
        Task<List<TodoItem>> GetAllTodoItems();
        // Define other CRUD methods here

        // Unit of Work functionality
        Task SaveChangesAsync();
    }
}
