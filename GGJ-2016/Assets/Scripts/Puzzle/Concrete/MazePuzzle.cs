using UnityEngine;
using System.Collections;

public class MazePuzzle: Puzzle {
    public TutorialControl player1;
    public TutorialControl player2;

    public float timeLimit;
    public float timeRemaining;

    private PuzzleStatus status;

    override public float GetTimeRemaining()
    {
        return timeRemaining;
    }

    override public float GetTimeLimit()
    {
        return timeLimit;
    }

    override public int GetDifficulty()
    {
        return 0;
    }

    /// <summary>
    /// Give the puzzle a name. My be useful later.
    /// </summary>
    override public string GetName()
    {
        return "Maze";
    }

    /// <summary>
    /// This should be called exactly once before actually running a puzzle.
    /// This will initialize all variables needed by the puzzle.
    /// Only put code that can execute in 1 frame here.
    /// </summary>
    override public void Setup()
    {
        timeRemaining = timeLimit;

        Vector3 camPosition = this.transform.FindChild("Camera Point").position;
        Camera cam1 = GameObject.Find("P1 Camera").GetComponent<Camera>();
        cam1.transform.position = camPosition;
        Camera cam2 = GameObject.Find("P2 Camera").GetComponent<Camera>();
        cam2.transform.position = camPosition;

        status = PuzzleStatus.INPROGRESS;
    }

    /// <summary>
    /// This should be called exactly once when the puzzle ends.
    /// This will do any cleanup for the puzzle (probably not needed??)
    /// Only put code that can execute in 1 frame here.
    /// </summary>
    override public void Cleanup()
    {
        Debug.Log("puzzle finished, should I ramp up the level of this puzzle?");
    }

    /// <summary>
    /// This is the main execution method for a puzzle.
    /// Should be called every Update() to run.
    /// </summary>
    override public void Execute()
    {
        timeRemaining -= Time.deltaTime;

        if (status == PuzzleStatus.INPROGRESS)
        {
            if (player1.col.IsTouching(player2.col))
            {
                player1.gameObject.layer = LayerMask.NameToLayer("Default");
                player2.gameObject.layer = LayerMask.NameToLayer("Default");
                if (Mathf.Abs(player1.transform.position.y - player2.transform.position.y) <= 0.2f && player1.transform.position.x < player2.transform.position.x)
                {
                    player1.enabled = false;
                    player2.enabled = false;
                    status = PuzzleStatus.SUCCESS;
                }
            }
            else
            {
                player1.gameObject.layer = LayerMask.NameToLayer("P1 ONLY");
                player2.gameObject.layer = LayerMask.NameToLayer("P2 ONLY");
            }
        }
    }

    /// <summary>
    /// This is the fixed execution method for a puzzle.
    /// Should be called in every FixedUpdate().
    /// Put physics related manipulations here.
    /// </summary>
    override public void FixedExecute()
    {
        //NO IDEA????
    }

    /// <summary>
    /// Returns the current puzzle status.
    /// Use this to determine if the puzzle is finished or in progress.
    /// Feel free to use PuzzleStatus.SPECIAL to do weird stuff with
    /// the PuzzleManager.
    /// </summary>
    override public PuzzleStatus Status()
    {
        if (timeRemaining < 0)
        {
            return PuzzleStatus.FAIL;
        }
        return status;
    }

    private const string INSTRUCTIONS = "Meet Up!";
    private const string CONTROLS = "LUDR";

    public override string GetP1Instructions()
    {
        return INSTRUCTIONS;
    }

    public override string GetP2Instructions()
    {
        return INSTRUCTIONS;
    }

    public override string GetP1Controls()
    {
        return CONTROLS;
    }

    public override string GetP2Controls()
    {
        return CONTROLS;
    }
}
