using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseDifficultyCommand : ICommand
{
    public void Execute()
    {
        UIManager.instance.RaiseDifficulty();
    }

    public void Undo()
    {
        UIManager.instance.LowerDifficulty();
    }
}
