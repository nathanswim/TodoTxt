using System.Collections.Generic;
using System.Linq;

namespace TodoList
{
    public class TodoList
    {
        readonly IRepository repository;

        public TodoList(IRepository repository)
        {
            this.repository = repository;
        }

        public void Add(string item)
        {
            var items = Load();
            items.Add(item);
            Save(items);
        }

        public void Remove(int index)
        {
            var items = Load();
            items.RemoveAt(index);
            Save(items);
        }

        public string[] List()
        {
            var list = Load();
            return list.ToArray();
        }

        public void Complete(int index)
        {
            var list = Load();
            list[index] = $"x {list[index]}";
            Save(list);
        }

        private void Save(IList<string> items)
        {
            repository.Save(items);
        }

        private IList<string> Load()
        {
            return repository.Load();
        }
    }
}
