using UnityEngine;
using System.Collections;

public class Pointer : MonoBehaviour {

    private const float LERP_SPEED = 0.5f;

    private Vector3 p1loc;
    private Vector3 p2loc;
    private Transform arrow;
    private int currentPlayer;

    public void SetFirst(int playerNum)
    {
        currentPlayer = playerNum;
    }

	// Use this for initialization
	void Start () {
        p1loc = transform.FindChild("P1 Loc").position;
        p2loc = transform.FindChild("P2 Loc").position;
        arrow = transform.FindChild("Arrow");
	}
	
	// Update is called once per frame
	void Update () {
	    if(currentPlayer == 0)
        {
            arrow.position = Vector3.Lerp(arrow.position, p1loc, LERP_SPEED);
        }
        else
        {
            arrow.position = Vector3.Lerp(arrow.position, p2loc, LERP_SPEED);
        }
	}

    public void PointAt(int playerNum)
    {
        currentPlayer = playerNum;
    }
}
