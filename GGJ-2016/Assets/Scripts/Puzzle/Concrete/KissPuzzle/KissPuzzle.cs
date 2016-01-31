using UnityEngine;
using System.Collections;

public class KissPuzzle : Puzzle
{
    private const string PUZZLE_NAME = "Kiss";
    private const string INSTRUCTIONS = "Kiss!";
    private const string CONTROLS = "A";

    public float timeLimit;

    private float timeRemaining;
    private PuzzleStatus status;
    private bool win;

    private KissPuzzlePlayer player1;
    private KissPuzzlePlayer player2;

	public AudioClip kissClip;
	public AudioClip kissFailClip;
	private AudioSource kissSound;
	public AudioSource kissFailSound;

	private AudioSource makeAudioSource(AudioClip clip, float volume) {
		AudioSource source = gameObject.AddComponent<AudioSource>();
		source.clip = clip;
		source.loop = false;
		source.playOnAwake = false;
		source.volume = volume;
		return source;
	}

	public void Awake() {
		this.kissSound = this.makeAudioSource (this.kissClip, 1.0f);
		this.kissFailSound = this.makeAudioSource (this.kissFailClip, 1.0f);
	}

    override public void P1_ButA()
    {
        if (player1.playerStatus == KissPuzzlePlayer.PlayerStatus.IDLE)
        {
            player1.Trigger();
        }
    }

    override public void P2_ButA()
    {
        if (player2.playerStatus == KissPuzzlePlayer.PlayerStatus.IDLE)
        {
            player2.Trigger();
        }
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
        return "See Saw Puzzle";
    }

    /// <summary>
    /// This should be called exactly once before actually running a puzzle.
    /// This will initialize all variables needed by the puzzle.
    /// Only put code that can execute in 1 frame here.
    /// </summary>
    override public void Setup()
    {
        timeRemaining = timeLimit;
        status = PuzzleStatus.INPROGRESS;
        win = false;

        Vector3 camPosition = this.transform.FindChild("Camera Point").position;
        Camera cam1 = GameObject.Find("P1 Camera").GetComponent<Camera>();
        cam1.transform.position = camPosition;
        Camera cam2 = GameObject.Find("P2 Camera").GetComponent<Camera>();
        cam2.transform.position = camPosition;

        player1 = this.transform.FindChild("P1").GetComponent<KissPuzzlePlayer>();
        player2 = this.transform.FindChild("P2").GetComponent<KissPuzzlePlayer>();
    }

    /// <summary>
    /// This should be called exactly once when the puzzle ends.
    /// This will do any cleanup for the puzzle (probably not needed??)
    /// Only put code that can execute in 1 frame here.
    /// </summary>
    override public void Cleanup()
    {
        Debug.Log("Kiss Puzzle done");
    }

    /// <summary>
    /// This is the main execution method for a puzzle.
    /// Should be called every Update() to run.
    /// </summary>
    override public void Execute()
    {
        switch(status)
        {
            case PuzzleStatus.INPROGRESS:
                timeRemaining -= Time.deltaTime;
                if(timeRemaining < 0.0f)
                {
                    timeRemaining = 0.0f;
                    status = PuzzleStatus.SPECIAL;
                }
                else
                {
                    if (player1.playerStatus == KissPuzzlePlayer.PlayerStatus.PRIMED
                        && player2.playerStatus == KissPuzzlePlayer.PlayerStatus.PRIMED)
                    {
                        player1.Succeed();
                        player2.Succeed();
						this.kissSound.Play ();
						
                        win = true;
                        status = PuzzleStatus.SPECIAL;
                    }
                }
                break;
            case PuzzleStatus.SPECIAL:
                // Special animation? :P
                if(win)
                {
                    status = PuzzleStatus.SUCCESS;
                }
                else
                {
                    status = PuzzleStatus.FAIL;
                }
                break;
            default:
                break;
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

