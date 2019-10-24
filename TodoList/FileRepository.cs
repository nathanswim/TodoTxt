using System.Collections.Generic;
using System.IO;

namespace TodoList
{
    public abstract class Repository : IRepository
    {
        public abstract void Reset();

        public IList<string> Load()
        {
            var list = new List<string>();
            using var reader = CreateReader();
            string line;
            while ((line = reader.ReadLine()) != null)
                list.Add(line);
            return list;
        }

        public void Save(IList<string> items)
        {
            using var writer = CreateWriter();
            foreach (var item in items)
                writer.WriteLine(item);
        }

        protected abstract TextReader CreateReader();
        protected abstract TextWriter CreateWriter();
    }

    public class FileRepository : Repository, IRepository
    {
        const string FILE_NAME = "todo.txt";

        public string FileName { get => FILE_NAME; }

        public override void Reset()
        {
            if (File.Exists(FileName))
                File.Delete(FileName);
        }

        protected override TextReader CreateReader()
        {
            if (!File.Exists(FileName))
                using (File.CreateText(FileName)) { }
            return File.OpenText(FileName);
        }

        protected override TextWriter CreateWriter()
        {
            return File.CreateText(FileName);
        }
    }

}
