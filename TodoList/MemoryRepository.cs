using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TodoList
{
    public class MemoryRepository : Repository, IRepository
    {
        StringBuilder repo = new StringBuilder();

        public override void Reset()
        {
            repo = new StringBuilder();
        }

        protected override TextReader CreateReader()
        {
            return new StringReader(repo.ToString());
        }

        protected override TextWriter CreateWriter()
        {
            Reset();
            return new StringWriter(repo);
        }
    }

}
