using UnityEngine;
using System.Collections;

public class WindPuzzle : Puzzle {

   //Need to time it so both players apples land in the basin at the same time

    public float timeLimit;
    private float timeRemaining;
    private PuzzleStatus status;

    public FallerPlayer fallingPlayer;
    public WindPlayer windPlayer;
    public GameObject catcher;
    private Collider2D catcherBounds;

    private CameraControls cam1;
    private CameraControls cam2;

    override public void P1_Direction(Vector2 dir)
    {
        if (fallingPlayer.assignment == FallerPlayer.PlayerAssignment.P1)
            fallingPlayer.steer(dir);
    }

    override public void P2_Direction(Vector2 dir)
    {
        if(fallingPlayer.assignment == FallerPlayer.PlayerAssignment.P2)
            fallingPlayer.steer(dir);
    }

    override public void P1_ButA()
    {
        if(windPlayer.assignment == WindPlayer.PlayerAssignment.P2)
            windPlayer.trigger();
    }
    override public void P2_ButA()
    {
        if (windPlayer.assignment == WindPlayer.PlayerAssignment.P2)
            windPlayer.trigger();
    }

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
        return "Wind";
    }

    /// <summary>
    /// This should be called exactly once before actually running a puzzle.
    /// This will initialize all variables needed by the puzzle.
    /// Only put code that can execute in 1 frame here.
    /// </summary>
    override public void Setup()
    {
        status = PuzzleStatus.INPROGRESS;

        timeRemaining = timeLimit;
        cam1 = GameObject.Find("P1 Camera").GetComponent<CameraControls>();
        cam1.Target(fallingPlayer.GetTarget());
        cam2 = GameObject.Find("P2 Camera").GetComponent<CameraControls>();
        cam2.Target(fallingPlayer.GetTarget());

        catcherBounds = catcher.GetComponent<Collider2D>();
    }

    /// <summary>
    /// This should be called exactly once when the puzzle ends.
    /// This will do any cleanup for the puzzle (probably not needed??)
    /// Only put code that can execute in 1 frame here.
    /// </summary>
    override public void Cleanup()
    {
        Time.timeScale = 1.0f;
        cam1.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        cam2.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    /// <summary>
    /// This is the main execution method for a puzzle.
    /// Should be called every Update() to run.
    /// </summary>
    override public void Execute()
    {
        if(status == PuzzleStatus.INPROGRESS)
        {
            timeRemaining -= Time.deltaTime;
            if (fallingPlayer.transform.position.y - catcher.transform.position.y < 20)
            {
                Time.timeScale = 0.5f;
            }
            if (timeRemaining < 0 || fallingPlayer.transform.position.y < catcher.transform.position.y - 2.0f)
            {
                Time.timeScale = 1.0f;
                status = PuzzleStatus.FAIL;
            }
            else if (fallingPlayer.colBody.bounds.Intersects(catcherBounds.bounds))
            {
                Time.timeScale = 1.0f;
                status = PuzzleStatus.SUCCESS;
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
        return status;
    }

    public override string GetP1Instructions()
    {
        return "Make it to your lover!";
    }

    public override string GetP2Instructions()
    {
        return "Create wind to help!";
    }

    public override string GetP1Controls()
    {
        return "LR";
    }

    public override string GetP2Controls()
    {
        return "A";
    }
}
