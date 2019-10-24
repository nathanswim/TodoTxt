using Xunit;

namespace TodoList
{

    public class TodoControllerTests
    {
        [Fact]
        public void CanAddItems()
        {
            var repo = new MemoryRepository();
            var todo = new TodoList(repo);
            var controller = new TodoController(todo);
            controller.Input("add item one");
            controller.Input("Add item two");
            controller.Input("aDD item three");

            var list = todo.List();
            Assert.Equal("item one", list[0]);
            Assert.Equal("item two", list[1]);
            Assert.Equal("item three", list[2]);
            Assert.Equal(3, list.Length);
        }

        [Fact]
        public void CanRemoveItem()
        {
            var repo = new MemoryRepository();
            var todo = new TodoList(repo);
            var controller = new TodoController(todo);
            controller.Input("add item one");
            controller.Input("add item two");
            controller.Input("add item three");
            controller.Input("del 2");

            var list = todo.List();
            Assert.Equal("item one", list[0]);
            Assert.Equal("item three", list[1]);
            Assert.Equal(2, list.Length);
        }

        [Fact]
        public void CanCompleteItem()
        {
            var repo = new MemoryRepository();
            var todo = new TodoList(repo);
            var controller = new TodoController(todo);
            controller.Input("add item one");
            controller.Input("add item two");
            controller.Input("add item three");
            controller.Input("complete 2");

            var list = todo.List();
            Assert.Equal("item one", list[0]);
            Assert.Equal("x item two", list[1]);
            Assert.Equal("item three", list[2]);
            Assert.Equal(3, list.Length);
        }
    }
}
