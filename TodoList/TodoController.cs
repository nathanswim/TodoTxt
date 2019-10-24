using System;

namespace TodoList
{
    public class TodoController
    {
        readonly TodoList todo;

        public TodoController(TodoList todo)
        {
            this.todo = todo;
        }

        public void Input(string commandText)
        {
            var command = GetCommand(commandText);
            command.Execute(todo);
        }

        private TodoCommand GetCommand(string commandText)
        {
            var tokens = commandText.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var command = tokens[0].ToLowerInvariant();
            var item = string.Join(' ', tokens, 1, tokens.Length - 1);
            return new TodoCommand(command, item);
        }
    }

    public class TodoCommand
    {
        public TodoCommand(string command, string item)
        {
            Command = command;
            Item = item;
        }

        public string Command { get; }
        public string Item { get; }

        public void Execute(TodoList todo)
        {
            if (Command == "add")
            {
                todo.Add(Item);
            }
            else if (Command == "del")
            {
                var index = int.Parse(Item) - 1;
                todo.Remove(index);
            }
            else if (Command == "complete")
            {
                var index = int.Parse(Item) - 1;
                todo.Complete(index);
            }
        }
    }
}
