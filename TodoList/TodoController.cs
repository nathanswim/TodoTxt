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
            var item = GetItem(commandText);
            command.Execute(todo, item);

        }

        private ITodoCommand GetCommand(string commandText)
        {
            var tokens = commandText.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var command = tokens[0].ToLowerInvariant();
            if (command == "add")
                return new AddTodoCommand();
            else if (command == "del")
                return new RemoveTodoCommand();
            else if (command == "complete")
                return new CompleteTodoCommand();
            return new EmptyTodoCommand();
        }

        private string GetItem(string commandText)
        {
            var tokens = commandText.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return string.Join(' ', tokens, 1, tokens.Length - 1);
        }
    }

    public interface ITodoCommand
    {
        void Execute(TodoList todo, string item);
    }

    public class AddTodoCommand : ITodoCommand
    {
        public void Execute(TodoList todo, string item)
        {
            todo.Add(item);
        }
    }

    public class RemoveTodoCommand : ITodoCommand
    {
        public void Execute(TodoList todo, string item)
        {
            var index = int.Parse(item) - 1;
            todo.Remove(index);
        }
    }

    public class CompleteTodoCommand : ITodoCommand
    {
        public void Execute(TodoList todo, string item)
        {
            var index = int.Parse(item) - 1;
            todo.Complete(index);
        }
    }

    public class EmptyTodoCommand : ITodoCommand
    {

        public void Execute(TodoList todo, string item)
        {
        }
    }
}
