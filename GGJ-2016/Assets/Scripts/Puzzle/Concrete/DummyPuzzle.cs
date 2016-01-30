using UnityEngine;
using System.Collections;

public class DummyPuzzle : Puzzle {

    private const float TIME_LIMIT = 10.0f;

    private float timeRemaining;
    private bool hold;
    private PuzzleStatus status;

    private Rigidbody2D dio;
    private Vector3 startPosition;

    public override float GetTimeRemaining()
    {
        return timeRemaining;
    }

    public override float GetTimeLimit()
    {
        return TIME_LIMIT;
    }

    public override int GetDifficulty()
    {
        return 0;
    }

    public override string GetName()
    {
        return "Dummy Puzzle";
    }

    public override void Setup()
    {
        timeRemaining = TIME_LIMIT;
        hold = true;
        status = PuzzleStatus.INPROGRESS;
        dio = this.transform.FindChild("Dio").GetComponent<Rigidbody2D>();
        startPosition = dio.position;
    }

    public override void Cleanup()
    {
        // Do nothing
    }

    public override void Execute()
    {
        if(timeRemaining >= 0.0f)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            status = PuzzleStatus.SUCCESS;
        }

        if(dio.position.y < -8.0f)
        {
            dio.position = startPosition;
            hold = true;
        }
        dio.isKinematic = hold;
    }

    public override void FixedExecute()
    {

    }

    public override PuzzleStatus Status()
    {
        return status;
    }

    public override void P1_ButA()
    {
        hold = false;
    }
}
