using Microsoft.EntityFrameworkCore;
using Todo.Models;

namespace Todo.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TodoContext _context;
        public ITodoRepository TodoRepository { get; }

        public UnitOfWork(TodoContext context, ITodoRepository todoRepository)
        {
            _context = context;
            TodoRepository = todoRepository;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

    public interface IUnitOfWork
    {
        ITodoRepository TodoRepository { get; }

        // Unit of Work functionality
        Task SaveChangesAsync();
    }
}
