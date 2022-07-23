using System.Collections.Generic;
using System.Linq;

public class CommandProcessor
{
    private Stack<ICommand> _commands;

    public CommandProcessor()
    {
        _commands = new Stack<ICommand>();
    }

    public void ExecuteCommand(ICommand command)
    {
        _commands.Push(command);
        command.Execute();
    }

    public void UndoCommand()
    {
        if (!_commands.Any())
            return;
        
        _commands.Pop().Undo();
    }

    public void RedoCommand()
    {
        return;
    }
}