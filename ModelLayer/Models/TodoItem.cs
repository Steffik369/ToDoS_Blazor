using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ModelLayer.Models
{
    public class TodoItem
    {
        public TodoItem(string title)
        {
            Title = title;
            Status = ItemStatus.Todo;
            DateAdded = DateTime.Now;
            DateLastUpdate = DateAdded;
        }

        public TodoItem(uint id, string title, ItemStatus status, DateTime dateAdded, DateTime dateLastUpdate)
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
        public DateTime DateAdded { get; private set; }
        public DateTime DateLastUpdate { get; private set; }

        public bool IsDone()
        {
            return Status == ItemStatus.Completed;
        }

        private void SetStatus<T>(ref T backingFiled, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingFiled, value)) return;
            backingFiled = value;
            DateLastUpdate = DateTime.Now;
        }
    }

    public enum ItemStatus
    {
        Todo,
        Started,
        Completed
    }
}
