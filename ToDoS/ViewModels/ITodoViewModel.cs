using ModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

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
