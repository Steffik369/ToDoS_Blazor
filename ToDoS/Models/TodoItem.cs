using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoS.Models
{
    public class TodoItem
    {
        public TodoItem()
        {
            IsDone = false;
        }

        public string Title { get; set; }
        public string Body { get; set; }
        public bool IsDone { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
