using UnityEngine;
using System.Collections;

public abstract class Puzzle : MonoBehaviour {

    // Player 1 controls
    public void P1_ButA() { }
    public void P1_ButB() { }
    public void P1_Direction(Vector2 dir) { }

    // Player 2 controls
    public void P2_ButA() { }
    public void P2_ButB() { }
    public void P2_Direction(Vector2 dir) { }

    // These are abstract functions.
    // Each puzzle _might_ have different notions of how to calculate
    // elapsed time, so we might as well do it this way instead
    // to provide the best flexibility.
    abstract public float GetTimeRemaining();
    abstract public float GetTimeLimit();

    /// <summary>
    /// Give some sort of difficulty to the puzzle here.
    /// May be useful later.
    /// </summary>
    abstract public int GetDifficulty();

    /// <summary>
    /// Give the puzzle a name. My be useful later.
    /// </summary>
    abstract public string GetName();

    /// <summary>
    /// This should be called exactly once before actually running a puzzle.
    /// This will initialize all variables needed by the puzzle.
    /// Only put code that can execute in 1 frame here.
    /// </summary>
    abstract public void Setup();

    /// <summary>
    /// This should be called exactly once when the puzzle ends.
    /// This will do any cleanup for the puzzle (probably not needed??)
    /// Only put code that can execute in 1 frame here.
    /// </summary>
    abstract public void Cleanup();

    /// <summary>
    /// This is the main execution method for a puzzle.
    /// Should be called every Update() to run.
    /// </summary>
    abstract public void Execute();

    /// <summary>
    /// This is the fixed execution method for a puzzle.
    /// Should be called in every FixedUpdate().
    /// Put physics related manipulations here.
    /// </summary>
    abstract public void FixedExecute();

    /// <summary>
    /// Returns the current puzzle status.
    /// Use this to determine if the puzzle is finished or in progress.
    /// Feel free to use PuzzleStatus.SPECIAL to do weird stuff with
    /// the PuzzleManager.
    /// </summary>
    abstract public PuzzleStatus Status();
}
