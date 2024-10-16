using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoker : MonoBehaviour
{
    private Stack<ICommand> undoStack = new Stack<ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        undoStack.Push(command);
    }

    public void UndoCommand()
    {
        if (undoStack.Count > 0)
        {
            undoStack.Pop().Undo();
        }
    }
}
