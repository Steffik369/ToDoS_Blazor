using Microsoft.EntityFrameworkCore;
using ToDoS.Shared.Models;

namespace TodoRepository.SQL
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        { }

        public DbSet<TodoItem> ToDoItems { get; set; }
    }
}
