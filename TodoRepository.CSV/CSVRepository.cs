using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ToDoS.Shared.Models;
using ToDoS.Shared.Repositories;

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
                sw.WriteLine(TodoItemToFileLine(todoItem));
            }
        }

        public void DeleteItem(TodoItem todoItem)
        {
            if (todoItem.Id == 0) return;
            if (!File.Exists(path)) throw new FileNotFoundException("Cannot find db file.");

            List<TodoItem> all_items = GetAllItems().Where(x => x.Id != todoItem.Id).ToList();
            File.WriteAllLines(path, all_items.OrderBy(item => item.Id).Select(item => TodoItemToFileLine(item)));
        }

        public IEnumerable<TodoItem> GetAllItems()
        {
            var todoItems = new List<TodoItem>();
            if (!File.Exists(path)) throw new FileNotFoundException("Cannot find db file.");
            
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
                        dateAdded: DateTimeOffset.Parse(elements[3]),
                        dateLastUpdate: DateTimeOffset.Parse(elements[4])
                    ));
                }
            }
            return todoItems;
        }

        public TodoItem GetItem(uint id)
        {
            return GetAllItems().Where(item => item.Id == id).FirstOrDefault();
        }

        public void UpdateItem(TodoItem todoItem)
        {
            if (todoItem.Id == 0) return;
            if (!File.Exists(path)) throw new FileNotFoundException("Cannot find db file.");

            List<TodoItem> all_items = GetAllItems().Where(x=>x.Id != todoItem.Id).ToList();
            all_items.Add(todoItem);

            File.WriteAllLines(path, all_items.OrderBy(item=>item.Id).Select(item=>TodoItemToFileLine(item)));
        }

        private string TodoItemToFileLine(TodoItem todoItem)
        {
            return $"{todoItem.Id}|{todoItem.Title}|{todoItem.Status}|{todoItem.DateAdded.ToString("O")}|{todoItem.DateLastUpdate.ToString("O")}";
        }

        private uint GetNewId()
        {
            return (GetAllItems().Select(item => (uint?)item.Id).OrderByDescending(id => id).FirstOrDefault() ?? 0) + 1;
        }
    }
}
