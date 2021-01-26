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
    public class TodoListViewModel : ITodoViewModel
    {
        public TodoListViewModel()
        {
            AddTodoItem(new TodoItem()
            {
                Title = "item 1",
                Body = "Body 1",
                DateAdded = DateTime.Now,
            });

            AddTodoItem(new TodoItem()
            {
                Title = "item 2",
                Body = "Body 2",
                DateAdded = DateTime.Now,
            });
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private bool isBusy = false;
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
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

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SaveToDoItem(TodoItem todoitem)
        {
            throw new NotImplementedException();
        }


        public void AddTodoItem(TodoItem todoitem)
        {
            IsBusy = true;
            if (todoitem == null) return;

            TodoItems.Add(todoitem);

            //OnPropertyChanged(nameof(ToDoItemList));
            isBusy = false; //TODO upravit isBussy
        }

        public void RemoveTodoItem(TodoItem todoitem)
        {
            IsBusy = true;
            if (todoitem == null) return;

            TodoItems.Remove(todoitem);

            //OnPropertyChanged(nameof(ToDoItemList));
            isBusy = false; //TODO upravit isBussy
        }
    }
}
