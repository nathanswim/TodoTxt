using Xunit;

namespace TodoList
{
    public class AppRunnerTests
    {
        [Fact]
        public void CommandLineArgsAreAssembledAndPassedToController()
        {
            var repo = new MemoryRepository();
            var todo = new TodoList(repo);
            var controller = new TodoController(todo);
            var runner = new AppRunner(controller);

            string[] args = new[] { "add", "task", "one" };
            runner.Run(args);

            Assert.Equal("task one", todo.List()[0]);
        }
    }
}
