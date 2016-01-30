using UnityEngine;
using System.Collections.Generic;

public class PuzzleManager : MonoBehaviour {

    // Prefab links
    /// <summary>
    /// Attach all concrete Puzzles to a Prefab, and then link them here.
    /// This will let our manager spawn each puzzle as necessary.
    /// </summary>
    public List<Puzzle> puzzlesPrefabs = new List<Puzzle>();

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
        if(puzzlesPrefabs.Count > 0)
        {
            currentPuzzle = SpawnPuzzle(puzzlesPrefabs[0]);
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
        // Hacky stuff
        if(Input.GetKeyDown(KeyCode.A))
        {
            currentPuzzle.P1_ButA();
        }

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
