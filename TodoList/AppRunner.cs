namespace TodoList
{
    public class AppRunner
    {
        readonly TodoController controller;

        public AppRunner(TodoController controller)
        {
            this.controller = controller;
        }

        public void Run(string[] args)
        {
            var commandText = string.Join(' ', args);
            controller.Input(commandText);
        }
    }
}
