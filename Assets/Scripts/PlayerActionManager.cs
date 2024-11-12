using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionManager : MonoBehaviour
{
    private Stack<string> actionStack = new Stack<string>();

    public void PerformAction(string action)
    {
        actionStack.Push(action);
        Debug.Log("Action Performed: " + action);
        // Implement the action logic here
    }

    public void UndoAction()
    {
        if (actionStack.Count > 0)
        {
            string lastAction = actionStack.Pop();
            Debug.Log("Action Undone: " + lastAction);
            // Implement the undo logic here
        }
        else
        {
            Debug.Log("No actions to undo.");
        }
    }
}
