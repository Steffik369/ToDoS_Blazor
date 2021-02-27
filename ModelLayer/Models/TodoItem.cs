using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ToDoS.Shared.Models
{
    public class TodoItem
    {
        public TodoItem(string title)
        {
            Title = title;
            Status = ItemStatus.Todo;
            DateAdded = DateTimeOffset.UtcNow;
            DateLastUpdate = DateAdded;
        }

        public TodoItem(uint id, string title, ItemStatus status, DateTimeOffset dateAdded, DateTimeOffset dateLastUpdate)
        {
            Id = id;
            Title = title;
            Status = status;
            DateAdded = dateAdded;
            DateLastUpdate = dateLastUpdate;
        }

        public uint Id { get; set; }
        public string Title { get; set; }

        private ItemStatus status;

        public ItemStatus Status {
            get => status;
            set
            {
                SetStatus(ref status, value);
            }
        }
        public DateTimeOffset DateAdded { get; private set; }
        public DateTimeOffset DateLastUpdate { get; private set; }

        public bool IsDone
        {
            get{ return Status == ItemStatus.Completed; }
        }

        private void SetStatus<T>(ref T backingFiled, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingFiled, value)) return;
            backingFiled = value;
            DateLastUpdate = DateTimeOffset.UtcNow;
        }
    }

    public enum ItemStatus
    {
        Todo,
        Started,
        Completed
    }
}
