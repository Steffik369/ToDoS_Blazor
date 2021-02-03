using ModelLayer.Models;
using System.Collections.Generic;

namespace ModelLayer.Repositories
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
