using System.Collections.Generic;
using System.ComponentModel;
using ToDoS.Shared.Models;

namespace ToDoS.ViewModels
{
    public interface ITodoViewModel
    {
        bool IsBusy { get; set; }

        List<TodoItem> TodoItems { get; }

        event PropertyChangedEventHandler PropertyChanged;

        void SaveToDoItem(TodoItem todoItem);
        void AddTodoItem(TodoItem todoItem);
        void RemoveTodoItem(TodoItem todoItem);
        void ChangeItemStatus(TodoItem todoItem);
        void CreateNewItem(string title);
    }
}
