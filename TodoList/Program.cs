using System;

namespace TodoList
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new FileRepository();
            var todo = new TodoList(repo);
            var controller = new TodoController(todo);
            var runner = new AppRunner(controller);
            runner.Run(args);
        }


    }
}
