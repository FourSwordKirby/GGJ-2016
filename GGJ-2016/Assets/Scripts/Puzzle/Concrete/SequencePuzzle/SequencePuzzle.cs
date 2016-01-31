using UnityEngine;
using System.Collections.Generic;

public class SequencePuzzle : Puzzle {

    private static char[] LEGAL_LETTERS = new char[] {'L', 'R', 'D', 'U', 'A', 'B'};

    public int totalSequenceLength = 12;
    public float timeLimit;

    private PuzzleStatus status;
    private float timeRemaining;
    private int turn = 0;
    private List<char> sequence;
    private bool inputCorrect;

    private SpeechBubble p1bubble;
    private SpeechBubble p2bubble;
    private Pointer pointer;

    // Camera stuff.
    private Vector3 oldCam1Pos;
    private Vector3 oldCam2Pos;
    private Vector3 camPosition;
    private Camera cam1;
    private Camera cam2;


    public override float GetTimeRemaining()
    {
        return timeRemaining;
    }

    public override float GetTimeLimit()
    {
        return timeLimit;
    }

    public override int GetDifficulty()
    {
        return 1;
    }

    public override string GetName()
    {
        return "Conversation";
    }

    public override void Setup()
    {
        status = PuzzleStatus.INPROGRESS;
        timeRemaining = timeLimit;
        turn = Random.Range(0, 2);
        sequence = new List<char>();
        for (int i = 0; i < totalSequenceLength; i++)
        {
            sequence.Add(LEGAL_LETTERS[Random.Range(0, 6)]);
        }
        inputCorrect = false;
        sequence[0] = 'A';

        // Bubbles
        p1bubble = this.transform.FindChild("P1 Bubble").GetComponent<SpeechBubble>();
        p2bubble = this.transform.FindChild("P2 Bubble").GetComponent<SpeechBubble>();
        p1bubble.Init();
        p2bubble.Init();
        ShowBubble(turn, sequence[0]);
        HideBubble((turn + 1) % 2);

        // Pointer
        pointer = this.transform.FindChild("Pointer").GetComponent<Pointer>();
        pointer.SetFirst(turn);


        // Adjust camera.
        // Save camera positions then move both to our camera point.
        camPosition = this.transform.FindChild("Camera Point").position;
        cam1 = GameObject.Find("P1 Camera").GetComponent<Camera>();
        oldCam1Pos = cam1.transform.position;
        cam1.transform.position = camPosition;
        cam2 = GameObject.Find("P2 Camera").GetComponent<Camera>();
        oldCam2Pos = cam2.transform.position;
        cam2.transform.position = camPosition;
    }

    public override void Cleanup()
    {
        cam1.transform.position = oldCam1Pos;
        cam2.transform.position = oldCam2Pos;
    }

    public override void Execute()
    {
        if(status == PuzzleStatus.INPROGRESS)
        {
            timeRemaining -= Time.deltaTime;
            if(timeRemaining <= 0.0f)
            {
                timeRemaining = 0.0f;
                status = PuzzleStatus.FAIL;
            }
            else
            {
                if(inputCorrect)
                {
                    HideBubble(turn);
                    turn = (turn + 1) % 2;
                    sequence.RemoveAt(0);
                    if (sequence.Count == 0)
                    {
                        status = PuzzleStatus.SUCCESS;
                        return;
                    }
                    else
                    {
                        inputCorrect = false;
                    }
                    ShowBubble(turn, sequence[0]);
                    pointer.PointAt(turn);
                }
            }
        }
    }

    public override void FixedExecute()
    {
        // Do nothing
    }

    public override PuzzleStatus Status()
    {
        return status;
    }

    private void ShowBubble(int player, char letter)
    {
        if(player == 0)
        {
            p1bubble.Display(letter);
        }
        else
        {
            p2bubble.Display(letter);
        }
    }
    
    private void HideBubble(int player)
    {
        if(player == 0)
        {
            p1bubble.Hide();
        }
        else
        {
            p2bubble.Hide();
        }
    }

    public override void P1_ButA()
    {
        if(turn == 0 && sequence[0] == 'A')
        {
            inputCorrect = true;
        }
    }

    public override void P1_ButB()
    {
        if (turn == 0 && sequence[0] == 'B')
        {
            inputCorrect = true;
        }
    }

    public override void P1_Direction(Vector2 dir)
    {
        if (turn == 0)
        {
            if(IsCorrectDirection(dir))
            {
                inputCorrect = true;
            }
        }
    }

    private bool IsCorrectDirection(Vector2 dir)
    {
        switch(Controls.ToCardinalDirection(dir))
        {
            case Parameters.InputDirection.North:
                if(sequence[0] == 'U')
                {
                    return true;
                }
                break;
            case Parameters.InputDirection.East:
                if (sequence[0] == 'R')
                {
                    return true;
                }
                break;
            case Parameters.InputDirection.South:
                if (sequence[0] == 'D')
                {
                    return true;
                }
                break;
            case Parameters.InputDirection.West:
                if (sequence[0] == 'L')
                {
                    return true;
                }
                break;
            default:
                return false;
        }
        return false;
    }

    public override void P2_ButA()
    {
        if (turn == 1 && sequence[0] == 'A')
        {
            inputCorrect = true;
        }
    }

    public override void P2_ButB()
    {
        if (turn == 1 && sequence[0] == 'B')
        {
            inputCorrect = true;
        }
    }

    public override void P2_Direction(Vector2 dir)
    {
        if (turn == 1)
        {
            if (IsCorrectDirection(dir))
            {
                inputCorrect = true;
            }
        }
    }
    private const string INSTRUCTIONS = "Strike up a conversation!";
    private const string CONTROLS = "ABUDLR";

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
