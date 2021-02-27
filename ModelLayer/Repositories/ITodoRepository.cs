using System.Collections.Generic;
using ToDoS.Shared.Models;

namespace ToDoS.Shared.Repositories
{
    public interface ITodoRepository
    {
        void AddItem(TodoItem todoItem);
        TodoItem GetItem(uint id);
        IEnumerable<TodoItem> GetAllItems();
        void UpdateItem(TodoItem todoItem);
        void DeleteItem(TodoItem todoItem);
    }
}
