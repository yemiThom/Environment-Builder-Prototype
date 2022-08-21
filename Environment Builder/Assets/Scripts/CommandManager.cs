using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    private Stack<IAction> historyStack = new Stack<IAction>();
    private Stack<IAction> redoHistoryStack = new Stack<IAction>();

    public void ExecuteCommand(IAction action)
    {
        action.ExecuteCommand();
        historyStack.Push(action);
        redoHistoryStack.Clear();
    }

    public void UndoCommand()
    {
        if(historyStack.Count > 0)
        {
            redoHistoryStack.Push(historyStack.Peek());
            historyStack.Pop().UndoCommand();
        }
    }

    public void RedoCommand()
    {
        if(redoHistoryStack.Count > 0)
        {
            historyStack.Push(redoHistoryStack.Peek());
            redoHistoryStack.Pop().ExecuteCommand();
        }
    }
}
