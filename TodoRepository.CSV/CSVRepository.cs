using ModelLayer.Models;
using ModelLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace TodoRepository.CSV
{
    public class CSVRepository : ITodoRepository
    {
        private string path;

        public CSVRepository()
        {
            var filename = "CSVRepository.txt"; //TODO: refactor to app settings?
            path = AppDomain.CurrentDomain.BaseDirectory + filename;
        }

        public void AddItem(TodoItem todoItem)
        {
            if (todoItem.Id != 0) return;

            todoItem.Id = GetNewId();

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(TodoItemToString(todoItem));
            }
        }

        public void DeleteItem(TodoItem todoItem)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetAllItems()
        {
            var todoItems = new List<TodoItem>();

            if (File.Exists(path))
            {
                using (var reader = new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] elements = line.Split('|');
                        todoItems.Add(new TodoItem(
                            id: uint.Parse(elements[0]),
                            title: elements[1],
                            status: (ItemStatus)Enum.Parse(typeof(ItemStatus), elements[2]),
                            dateAdded: DateTime.Parse(elements[3]),
                            dateLastUpdate: DateTime.Parse(elements[4])
                        ));
                    }
                }
            }
            return todoItems;
        }

        public TodoItem GetItem(uint id)
        {
            return GetAllItems().Where(x => x.Id == id).FirstOrDefault();
        }

        public void UpdateItem(TodoItem todoItem)
        {
            if(todoItem.Id == 0)
            {
                AddItem(todoItem);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private string TodoItemToString(TodoItem todoItem)
        {
            return $"{todoItem.Id}|{todoItem.Title}|{todoItem.Status}|{todoItem.DateAdded.ToString()}|{todoItem.DateLastUpdate.ToString()}";
        }

        private uint GetNewId()
        {
            return ((GetAllItems().Select(x => (uint?)x.Id).OrderByDescending(x => x).FirstOrDefault() ?? 0) + 1);
        }
    }
}
