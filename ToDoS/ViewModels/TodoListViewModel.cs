using ModelLayer.Models;
using ModelLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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
            if (todoItem == null) throw new ArgumentNullException(nameof(todoItem), "Not item given.");

            TodoRepository.UpdateItem(todoItem);
        }

        public void ChangeItemStatus(TodoItem todoItem)
        {
            if (todoItem == null) throw new ArgumentNullException(nameof(todoItem), "Not item given.");

            todoItem.Status = todoItem.Status == ItemStatus.Todo ? ItemStatus.Completed : ItemStatus.Todo;
            SaveToDoItem(todoItem);
        }

        public void AddTodoItem(TodoItem todoItem)
        {
            if (todoItem == null) throw new ArgumentNullException(nameof(todoItem), "Not item given.");

            TodoRepository.AddItem(todoItem);
            TodoItems = TodoRepository.GetAllItems().ToList();
        }

        public void CreateNewItem(string title)
        {
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentOutOfRangeException(nameof(title), "Title cannot be empty.");

            AddTodoItem(new TodoItem(title: title));
        }

        public void RemoveTodoItem(TodoItem todoItem)
        {
            if (todoItem == null) throw new ArgumentNullException(nameof(todoItem), "Not item given.");

            TodoRepository.DeleteItem(todoItem);
            TodoItems = TodoRepository.GetAllItems().ToList();
        }
    }
}