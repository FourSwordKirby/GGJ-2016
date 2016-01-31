using UnityEngine;
using System.Collections;

public class ApplePuzzle : Puzzle {

   //Need to time it so both players apples land in the basin at the same time

    public float timeLimit;
    private float timeRemaining;

    public ApplePuzzlePlayer player1;
    public ApplePuzzlePlayer player2;

    private bool P1_PRESSED;
    private bool P2_PRESSED;

	private PuzzleStatus status;

	public AudioClip dropClip;
	public AudioClip splashClip;
	public AudioSource dropSound;
	public AudioSource splashSound;

	private AudioSource makeAudioSource(AudioClip clip, float volume) {
		AudioSource source = gameObject.AddComponent<AudioSource>();
		source.clip = clip;
		source.loop = false;
		source.playOnAwake = false;
		source.volume = volume;
		return source;
	}

	public void Awake() {
		this.dropSound = this.makeAudioSource (this.dropClip, 0.6f);
		this.splashSound = this.makeAudioSource (this.splashClip, 1.0f);
	}

    override public void P1_ButA()
    {
        if(player1.playerStatus == ApplePuzzlePlayer.PlayerStatus.READY)
            player1.trigger();
    }

    override public void P2_ButA()
    {
        if (player2.playerStatus == ApplePuzzlePlayer.PlayerStatus.READY)
            player2.trigger();
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
        return "Apples";
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
        //Initialize position of players?
        //Initialize some stats?
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
        if(status == PuzzleStatus.INPROGRESS)
        {
            timeRemaining -= Time.deltaTime;
            if (player1.playerStatus == ApplePuzzlePlayer.PlayerStatus.PRIMED && player2.playerStatus == ApplePuzzlePlayer.PlayerStatus.PRIMED)
            {
                status = PuzzleStatus.SUCCESS;
            }
            else if (timeRemaining < 0)
            {
                status = PuzzleStatus.FAIL;
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
    
    private const string INSTRUCTIONS = "Splash the water together!";
    private const string CONTROLS = "A";

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
