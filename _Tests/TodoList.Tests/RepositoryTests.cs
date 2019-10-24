using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace TodoList
{
    public abstract class RepositoryTests<T> where T : IRepository
    {
        protected abstract T CreateRepository();

        [Fact]
        public void CanSaveAndLoad()
        {
            var repo = CreateRepository();
            var expected = new List<string> { "one", "two" };
            repo.Save(expected);
            var actual = repo.Load();
            Assert.Equal(expected[0], actual[0]);
            Assert.Equal(expected[1], actual[1]);
            Assert.Equal(expected.Count, actual.Count);
        }

        [Fact]
        public void ResetClearsRepo()
        {
            var repo = CreateRepository();
            var expected = new List<string> { "one", "two" };
            repo.Save(expected);
            repo.Reset();
            var actual = repo.Load();
            Assert.Empty(actual);
        }
    }

    public sealed class FileRepositoryTests : RepositoryTests<FileRepository>, IDisposable
    {
        protected override FileRepository CreateRepository()
        {
            return new FileRepository();
        }

        [Fact]
        public void ResetDeletesFile()
        {
            var repo = CreateRepository();
            repo.Save(new List<string>());
            repo.Reset();
            Assert.False(File.Exists(repo.FileName), "File should be deleted");
        }

        [Fact]
        public void CreatesFileWhenNoneExists()
        {
            var repo = CreateRepository();
            repo.Save(new List<string>());
            Assert.True(File.Exists(repo.FileName), "File not found.");
        }

        public void Dispose()
        {
            var repo = CreateRepository();
            var file = repo.FileName;
            if (File.Exists(file))
                File.Delete(file);
        }
    }

    public class MemoryRepositoryTests : RepositoryTests<MemoryRepository>
    {
        protected override MemoryRepository CreateRepository()
        {
            return new MemoryRepository();
        }
    }

}
