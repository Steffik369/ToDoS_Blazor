using ModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
