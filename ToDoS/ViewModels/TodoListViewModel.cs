using ModelLayer.Models;
using ModelLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TodoRepository.CSV;

namespace ToDoS.ViewModels
{
    public class TodoListViewModel : BaseViewModel, ITodoViewModel
    {
        ITodoRepository TodoRepository;
        public TodoListViewModel()
        {
            TodoRepository = new CSVRepository();
            todoItems = TodoRepository.GetAllItems().ToList();
            //AddTodoItem(new TodoItem("Item 1"));
            //AddTodoItem(new TodoItem("Item 2"));
        }

        private List<TodoItem> todoItems = new List<TodoItem>();
        public List<TodoItem> TodoItems
        {
            get => todoItems;
            private set
            {
                todoItems = value;
                OnPropertyChanged();
            }
        }

        public void SaveToDoItem(TodoItem todoItem)
        {
            throw new NotImplementedException();
        }

        public void ChangeItemStatus(TodoItem todoItem)
        {
            IsBusy = true;
            todoItem.Status = todoItem.Status == ItemStatus.Todo ? ItemStatus.Completed : ItemStatus.Todo;
            IsBusy = false;
        }

        public void AddTodoItem(TodoItem todoItem)
        {
            IsBusy = true;
            if (todoItem == null) return;

            TodoRepository.AddItem(todoItem);
            TodoItems = TodoRepository.GetAllItems().ToList();
            //TodoItems.Add(todoItem);

            IsBusy = false;
        }

        public void CreateNewItem(string title)
        {
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Title cannot be empty");

            AddTodoItem(new TodoItem(title: title));
        }

        public void RemoveTodoItem(TodoItem todoItem)
        {
            throw new NotImplementedException();
        }
    }
}