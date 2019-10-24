using System.Collections.Generic;

namespace TodoList
{
    public interface IRepository
    {
        void Reset();
        void Save(IList<string> items);
        IList<string> Load();
    }


}
