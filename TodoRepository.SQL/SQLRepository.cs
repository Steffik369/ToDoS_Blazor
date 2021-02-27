using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoS.Shared.Models;
using ToDoS.Shared.Repositories;

namespace TodoRepository.SQL
{
    public class SQLRepository : ITodoRepository, IDesignTimeDbContextFactory<TodoContext>
    {
        DbContextOptions<TodoContext> options;

        public SQLRepository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<TodoContext>();
            optionsBuilder.UseSqlite("Data Source=../TodoRepository.SQL/ToDo.db");
            options = optionsBuilder.Options;
        }

        public void AddItem(TodoItem todoItem)
        {
            TodoContext todoContext = new TodoContext(options);

            todoContext.Add(todoItem);
            todoContext.SaveChanges();
        }

        public TodoContext CreateDbContext(string[] args)
        {
            return new TodoContext(options);
        }

        public void DeleteItem(TodoItem todoItem)
        {
            TodoContext todoContext = new TodoContext(options);

            todoContext.Remove(todoItem);
            todoContext.SaveChanges();
        }

        public IEnumerable<TodoItem> GetAllItems()
        {
            TodoContext todoContext = new TodoContext(options);

            return todoContext.ToDoItems;
        }

        public TodoItem GetItem(uint id)
        {
            TodoContext todoContext = new TodoContext(options);

            return todoContext.ToDoItems.Where(todoItem => todoItem.Id == id).FirstOrDefault();
        }

        public void UpdateItem(TodoItem todoItem)
        {
            TodoContext todoContext = new TodoContext(options);

            todoContext.Add(todoItem);
            todoContext.Entry(todoItem).State = EntityState.Modified;
            todoContext.SaveChanges();
        }
    }
}
