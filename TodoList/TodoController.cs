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
            if (command.Command == "add")
            {
                todo.Add(command.Item);
            }
            else if (command.Command == "del")
            {
                var index = int.Parse(command.Item) - 1;
                todo.Remove(index);
            }
            else if (command.Command == "complete")
            {
                var index = int.Parse(command.Item) - 1;
                todo.Complete(index);
            }

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
    }
}
