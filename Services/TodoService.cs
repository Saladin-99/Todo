using Todo.Models;
using Todo.Repositories;

namespace Todo.Services
{
    public class TodoService : ITodoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TodoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TodoItem> CreateTodoItem(TodoItem todoItem)
        {
            // Perform repository operation
            var createdTodoItem = await _unitOfWork.TodoRepository.CreateTodoItem(todoItem);

            // Commit changes using Unit of Work
            await _unitOfWork.SaveChangesAsync();

            return createdTodoItem;
        }

        public async Task<List<TodoItem>> GetAllTodoItems()
        {
            // Perform repository operation
            var todoItems = await _unitOfWork.TodoRepository.GetAllTodoItems();

            return todoItems;
        }

        // Other service methods can be implemented here
    }

    public interface ITodoService
    {
        Task<TodoItem> CreateTodoItem(TodoItem todoItem);
        Task<List<TodoItem>> GetAllTodoItems();
        // Define other service methods here
    }
}
