using UnityEngine;
using System.Collections.Generic;

public class PuzzleManager : MonoBehaviour
{

    // Prefab links
    /// <summary>
    /// Attach all concrete Puzzles to a Prefab, and then link them here.
    /// This will let our manager spawn each puzzle as necessary.
    /// </summary>
    public List<Puzzle> puzzlesPrefabs = new List<Puzzle>();
    public int initialPuzzleIndex = -1;

    //Global Progress Properties
    public int puzzleCount;
    public int remainingFailures;
    public float breakDuration = 3.0f;

    // Internal variables
    private Puzzle currentPuzzle;
    private bool run;
    private List<Puzzle> puzzlesToComplete = new List<Puzzle>();
    private int progress;
    private float breakTime;

	// Audio effects
	public AudioClip puzzleSuccessClip;
	public AudioClip puzzleFailClip;
	private AudioSource puzzleSuccessSound;
	private AudioSource puzzleFailSound;

    private bool transitionGuard;
    // Public properties
    public float TimeRemaining
    {
        get
        {
            if (currentPuzzle)
            {
                return currentPuzzle.GetTimeRemaining();
            }
            else
            {
                return 999.0f;
            }
        }
    }

    // Other object references
    private UIManager uiManager;

	private AudioSource makeAudioSource(AudioClip clip, float volume) {
		AudioSource source = gameObject.AddComponent<AudioSource>();
		source.clip = clip;
		source.loop = false;
		source.playOnAwake = false;
		source.volume = volume;
		return source;
	}

    void Awake()
    {
        transitionGuard = false;
        TransitionManager.Instance.SetScreenEmpty();
        run = false;
        breakTime = -1.0f;
		puzzleSuccessSound = makeAudioSource (puzzleSuccessClip, 1.0f);
		puzzleFailSound = makeAudioSource (puzzleFailClip, 1.0f);
    }

    // Use this for initialization
    void Start()
    {
        progress = 0;
        uiManager = GameObject.FindObjectOfType<UIManager>();

        if (initialPuzzleIndex >= 0)
        {
            List<Puzzle> puzzleSet = new List<Puzzle>(puzzlesPrefabs.ToArray());
            for (int i = 0; i < puzzleCount + remainingFailures; i++)
            {
                puzzlesToComplete.Add(puzzleSet[initialPuzzleIndex]);
            }
            currentPuzzle = SpawnPuzzle(puzzlesPrefabs[initialPuzzleIndex]);
        }
        else
        {
            List<Puzzle> puzzleSet = new List<Puzzle>(puzzlesPrefabs.ToArray());
            for (int i = 0; i < puzzleCount + remainingFailures; i++)
            {
                int puzzleIndex = Random.Range(0, puzzleSet.Count);
                puzzlesToComplete.Add(puzzleSet[puzzleIndex]);
                puzzleSet.RemoveAt(puzzleIndex);
                if (puzzleSet.Count == 0)
                    puzzleSet = new List<Puzzle>(puzzlesPrefabs.ToArray());
            }
            currentPuzzle = SpawnPuzzle(puzzlesToComplete[progress]);
        }
        SetupCurrentPuzzle();

        Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (!run)
        {
            return;
        }
        GetInputs();
        if (!IsDone(currentPuzzle.Status()))
        {
            uiManager.SetBothTimers(currentPuzzle.GetTimeRemaining());
            currentPuzzle.Execute();
        }
        else
        {
            if(breakTime <= 0.0f)
            {
                breakTime = breakDuration;
                if (currentPuzzle.Status() == PuzzleStatus.SUCCESS)
                {
					puzzleSuccessSound.Play ();
                    uiManager.PlaySuccessAnimation();
                }
                else
                {
					puzzleFailSound.Play ();
                    uiManager.PlayFailAnimation();
                }
            }
            else
            {
                breakTime -= Time.deltaTime;
                if (breakTime <= 0.0f)
                {
                    Debug.Log("Next!");
                    uiManager.ClearResults();
                    progress++;
                    currentPuzzle.Cleanup();
                    Destroy(currentPuzzle.gameObject);
                    if (progress < puzzlesToComplete.Count)
                    {
                        currentPuzzle = SpawnPuzzle(puzzlesToComplete[progress]);
                        SetupCurrentPuzzle();
                    }
                    if (currentPuzzle.Status() == PuzzleStatus.FAIL)
                    {
                        remainingFailures--;
                    }
                }
            }
        }

        if (progress == puzzlesToComplete.Count - remainingFailures && !transitionGuard)
        {
            transitionGuard = true;
            run = false;
            TransitionManager.Instance.FadeToWhite(() => Application.LoadLevel("VictoryScene"));
        }
        if (remainingFailures == 0 && !transitionGuard)
        {
            transitionGuard = true;
            run = false;
            TransitionManager.Instance.FadeToWhite(() => Application.LoadLevel("GameOverScene"));
        }
    }

    private void SetupCurrentPuzzle()
    {
        currentPuzzle.Setup();
        uiManager.SetInstructionsAndControls(0, currentPuzzle.GetP1Instructions(), currentPuzzle.GetP1Controls());
        uiManager.SetInstructionsAndControls(1, currentPuzzle.GetP2Instructions(), currentPuzzle.GetP2Controls());
    }

    void FixedUpdate()
    {
        currentPuzzle.FixedExecute();
    }

    public void Run()
    {
        run = true;
    }

    /// <summary>
    /// Move this to a separate class later.
    /// It's not going to be easy unless we expose currentPuzzle.
    /// </summary>
    private void GetInputs()
    {
        // P2_A is mapped to .
        // P2_B is mapped to /

        // P1_A is mapped to F
        // P2_B is mapped to G

        // Player 1
        if (Controls.AInputDown(0))
        {
            currentPuzzle.P1_ButA();
        }
        if (Controls.BInputDown(0))
        {
            currentPuzzle.P1_ButB();
        }
        currentPuzzle.P1_Direction(Controls.GetDirection(0));

        // Player 2
        if (Controls.AInputDown(1))
        {
            currentPuzzle.P2_ButA();
        }
        if (Controls.BInputDown(1))
        {
            currentPuzzle.P2_ButB();
        }
        currentPuzzle.P2_Direction(Controls.GetDirection(1));
    }

    private Puzzle SpawnPuzzle(Puzzle p)
    {
        Puzzle newPuzzle = GameObject.Instantiate<Puzzle>(p);
        newPuzzle.transform.SetParent(this.transform);
        return newPuzzle;
    }

    private bool IsDone(PuzzleStatus status)
    {
        return status == PuzzleStatus.SUCCESS || status == PuzzleStatus.FAIL;
    }
}
