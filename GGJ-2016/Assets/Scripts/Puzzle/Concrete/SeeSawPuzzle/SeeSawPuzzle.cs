using UnityEngine;
using System.Collections;

public class SeeSawPuzzle : Puzzle {

    private const string PUZZLE_NAME = "See Saw Puzzle";
    private const float TIME_LIMIT = 10.0f;

    private float remainingTime;


    public override void Setup()
    {
        remainingTime = TIME_LIMIT;
    }

    public override void Cleanup()
    {
        throw new System.NotImplementedException();
    }

    public override void Execute()
    {
        throw new System.NotImplementedException();
    }

    public override void FixedExecute()
    {
        throw new System.NotImplementedException();
    }

    public override PuzzleStatus Status()
    {
        throw new System.NotImplementedException();
    }

    public override float GetTimeRemaining()
    {
        throw new System.NotImplementedException();
    }

    public override float GetTimeLimit()
    {
        throw new System.NotImplementedException();
    }

    public override int GetDifficulty()
    {
        throw new System.NotImplementedException();
    }

    public override string GetName()
    {
        return PUZZLE_NAME;
    }
}
