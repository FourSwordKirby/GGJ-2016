using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {
    
    private PuzzleUI p1;
    private PuzzleUI p2;

	// Use this for initialization
	void Awake () {
        p1 = GameObject.Find("P1 Camera").GetComponentInChildren<PuzzleUI>();
        p2 = GameObject.Find("P2 Camera").GetComponentInChildren<PuzzleUI>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void SetBothTimers(float time)
    {
        p1.SetTime(time);
        p2.SetTime(time);
    }

    public void SetInstructionsAndControls(int playerNum, string instr, string controls)
    {
        if(playerNum == 0)
        {
            p1.SetInstructions(instr);
            p1.SetControls(controls);
        }
        else
        {
            p2.SetInstructions(instr);
            p2.SetControls(controls);
        }
    }

    public void PlaySuccessAnimation()
    {
        p1.PlaySuccessAnimation();
        p2.PlaySuccessAnimation();
    }

    public void PlayFailAnimation()
    {
        p1.PlayFailAnimation();
        p2.PlayFailAnimation();
    }

    public void ClearResults()
    {
        p1.StopResultAnimation();
        p2.StopResultAnimation();
    }
}
