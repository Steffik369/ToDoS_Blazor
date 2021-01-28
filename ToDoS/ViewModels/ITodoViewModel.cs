using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using ToDoS.Models;

namespace ToDoS.ViewModels
{
    public interface ITodoViewModel
    {
        bool IsBusy { get; set; }
        ObservableCollection<TodoItem> TodoItems { get; }

        event PropertyChangedEventHandler PropertyChanged;

        void SaveToDoItem(TodoItem todoitem);
        void AddTodoItem(TodoItem todoitem);
        void RemoveTodoItem(TodoItem todoitem);
        void ChangeItemStatus(TodoItem todoitem);
    }
}
