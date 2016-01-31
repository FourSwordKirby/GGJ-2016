using UnityEngine;
using System.Collections;

public class WindPlayer : MonoBehaviour {
    public enum PlayerAssignment
    {
        P1,
        P2
    }
    public PlayerAssignment assignment;

    public FallerPlayer fallingPlayer;

    public void trigger()
    {
        fallingPlayer.selfBody.AddForce(new Vector2(0, 1));
        Debug.Log("woosh");
    }
}
