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
        Run();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(!run)
        {
            return;
        }
	}

    public void Run()
    {
        run = true;
    }
}
