using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ToDoS.Models;

namespace ToDoS.ViewModels
{
    public class TodoListViewModel : BaseViewModel, ITodoViewModel
    {
        public TodoListViewModel()
        {
            AddTodoItem(new TodoItem(title: "Item 1", description: "Hodně dlouhý popis, ale fakt podrobný, ukolu 1."));
            AddTodoItem(new TodoItem(title: "Item 2", description: "popis_ukolu_2"));
        }

        private ObservableCollection<TodoItem> todoItems = new ObservableCollection<TodoItem>();
        public ObservableCollection<TodoItem> TodoItems
        {
            get => todoItems;
            private set
            {
                todoItems = value;
                OnPropertyChanged();
            }
        }

        public void SaveToDoItem(TodoItem todoitem)
        {
            throw new NotImplementedException();
        }

        public void ChangeItemStatus(TodoItem todoitem)
        {
            IsBusy = true;
            todoitem.Status = todoitem.Status == ItemStatus.Todo ? ItemStatus.Completed : ItemStatus.Todo;
            IsBusy = false;
        }

        public void AddTodoItem(TodoItem todoitem)
        {
            IsBusy = true;
            if (todoitem == null) return;

            TodoItems.Add(todoitem);

            IsBusy = false;
        }

        public void RemoveTodoItem(TodoItem todoitem)
        {
            IsBusy = true;
            if (todoitem == null) return;

            TodoItems.Remove(todoitem);

            IsBusy = false;
        }
    }
}