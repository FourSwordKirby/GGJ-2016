using UnityEngine;
using System.Collections.Generic;

public class PuzzleManager : MonoBehaviour {

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
    private List<Puzzle> puzzlesToComplete = new List<Puzzle>();
    private int progress;

    // Internal variables
    private Puzzle currentPuzzle;
    private bool run;

    // Public properties
    public float TimeRemaining
    {
        get
        {
            if(currentPuzzle)
            {
                return currentPuzzle.GetTimeRemaining();
            }
            else
            {
                return 999.0f;
            }
        }
    }

    void Awake()
    {
        run = false;
    }

	// Use this for initialization
	void Start ()
    {
        progress = 0;
        if (initialPuzzleIndex >= 0)
        {
            for (int i = 0; i < remainingFailures + 1; i++ )
            {
                puzzlesToComplete.Add(puzzlesPrefabs[initialPuzzleIndex]);
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

        Run();
	}
	
	// Update is called once per frame
	void Update()
    {
	    if(!run)
        {
            return;
        }
        GetInputs();
        currentPuzzle.Execute();
        if (currentPuzzle.Status() == PuzzleStatus.SUCCESS)
        {
            progress++;
            currentPuzzle.Cleanup();
            Destroy(currentPuzzle.gameObject);
            if(progress < puzzlesToComplete.Count)
                currentPuzzle = SpawnPuzzle(puzzlesToComplete[progress]);
        }
        else if(currentPuzzle.Status() == PuzzleStatus.FAIL)
        {
            progress++;
            currentPuzzle.Cleanup();
            Destroy(currentPuzzle.gameObject);
            if (progress < puzzlesToComplete.Count)
                currentPuzzle = SpawnPuzzle(puzzlesToComplete[progress]);
            remainingFailures--;
        }

        if (progress == puzzlesToComplete.Count-remainingFailures)
        {
            Debug.Log("YOU WIN");
        }
        if (remainingFailures == 0)
        {
            Debug.Log("YOU LOSE");
        }
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
        if(Controls.AInputDown(0))
        {
            currentPuzzle.P1_ButA();
        }
        if(Controls.BInputDown(0))
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
        newPuzzle.Setup();
        return newPuzzle;
    }
}
