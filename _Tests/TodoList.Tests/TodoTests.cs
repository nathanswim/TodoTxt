using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Xunit;

namespace TodoList
{

    public class TodoTests
    {
        readonly IRepository repository;

        public TodoTests()
        {
            repository = new MemoryRepository();
        }

        [Fact]
        public void AddOneItemToList()
        {
            var todo = new TodoList(repository);
            todo.Add("task one");
            var list = todo.List();
            Assert.Single(list);
            Assert.Equal("task one", list[0]);
        }

        [Fact]
        public void AddTwoItemsToList()
        {
            var todo = new TodoList(repository);
            todo.Add("task one");
            todo.Add("task two");
            var list = todo.List();
            Assert.Equal(2, list.Length);
            Assert.Equal("task one", list[0]);
            Assert.Equal("task two", list[1]);
        }

        [Fact]
        public void RemoveDeletesItemFromList()
        {
            var todo = new TodoList(repository);
            todo.Add("task one");
            todo.Add("task two");
            todo.Add("task three");
            todo.Remove(1);
            var list = todo.List();
            Assert.Equal(2, list.Length);
            Assert.Equal("task one", list[0]);
            Assert.Equal("task three", list[1]);
        }

        [Fact]
        public void CompleteMarksItemAsComplete()
        {
            var todo = new TodoList(repository);
            todo.Add("task one");
            todo.Add("task two");
            todo.Add("task three");
            todo.Complete(1);
            var list = todo.List();
            Assert.Equal("task one", list[0]);
            Assert.Equal("x task two", list[1]);
            Assert.Equal("task three", list[2]);
            Assert.Equal(3, list.Length);
        }
    }
}
