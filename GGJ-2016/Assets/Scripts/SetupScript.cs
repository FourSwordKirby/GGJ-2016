using UnityEngine;
using System.Collections;

public class SetupScript : MonoBehaviour {

    private int p1status = 0;
    private int p2status = 0;

    private GameObject[] p1stuff;
    private GameObject[] p2stuff;

    private bool transitionGuard = false;

    void Start()
    {
        p1stuff = new GameObject[6];
        for(int i = 0; i < 6; i++)
        {
            p1stuff[i] = this.transform.FindChild("1_" + i).gameObject;
        }
        p2stuff = new GameObject[6];
        for (int i = 0; i < 6; i++)
        {
            p2stuff[i] = this.transform.FindChild("1_" + i + " (1)").gameObject;
        }
    }

	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.F1))
        {
            Screen.SetResolution(3800, 1000, false);
        }

        switch(p1status)
        {
            case 0:
                if (Controls.GetCardinalDirection(0) == Parameters.InputDirection.West)
                {
                    Destroy(p1stuff[p1status]);
                    p1status++;
                }
                break;
            case 1:
                if (Controls.GetCardinalDirection(0) == Parameters.InputDirection.East)
                {
                    Destroy(p1stuff[p1status]);
                    p1status++;
                }
                break;
            case 2:
                if (Controls.GetCardinalDirection(0) == Parameters.InputDirection.North)
                {
                    Destroy(p1stuff[p1status]);
                    p1status++;
                }
                break;
            case 3:
                if (Controls.GetCardinalDirection(0) == Parameters.InputDirection.South)
                {
                    Destroy(p1stuff[p1status]);
                    p1status++;
                }
                break;
            case 4:
                if (Controls.AInputDown(0))
                {
                    Destroy(p1stuff[p1status]);
                    p1status++;
                }
                break;
            case 5:
                if (Controls.BInputDown(0))
                {
                    Destroy(p1stuff[p1status]);
                    p1status = -1;
                }
                break;
            default:
                p1status = -1;
                break;
        }

        switch (p2status)
        {
            case 0:
                if (Controls.GetCardinalDirection(1) == Parameters.InputDirection.West)
                {
                    Destroy(p2stuff[p2status]);
                    p2status++;
                }
                break;
            case 1:
                if (Controls.GetCardinalDirection(1) == Parameters.InputDirection.East)
                {
                    Destroy(p2stuff[p2status]);
                    p2status++;
                }
                break;
            case 2:
                if (Controls.GetCardinalDirection(1) == Parameters.InputDirection.North)
                {
                    Destroy(p2stuff[p2status]);
                    p2status++;
                }
                break;
            case 3:
                if (Controls.GetCardinalDirection(1) == Parameters.InputDirection.South)
                {
                    Destroy(p2stuff[p2status]);
                    p2status++;
                }
                break;
            case 4:
                if (Controls.AInputDown(1))
                {
                    Destroy(p2stuff[p2status]);
                    p2status++;
                }
                break;
            case 5:
                if (Controls.BInputDown(1))
                {
                    Destroy(p2stuff[p2status]);
                    p2status = -1;
                }
                break;
            default:
                p2status = -1;
                break;
        }

        if(p1status < 0 && p2status < 0 && !transitionGuard)
        {
            TransitionManager.Instance.FadeToWhite(() => Application.LoadLevel("IntroScene"));
            transitionGuard = true;
        }
	}
}
