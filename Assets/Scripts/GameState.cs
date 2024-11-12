using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState
{
    public readonly int level;
    public readonly int experience;

    public GameState(int level, int experience)
    {
        this.level = level;
        this.experience = experience;
    }

    public GameState LevelUp()
    {
        return new GameState(this.level + 1, this.experience);
    }

    public GameState AddExperience(int amount)
    {
        return new GameState(this.level, this.experience + amount);
    }
}
