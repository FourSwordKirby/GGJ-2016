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
        //fallingPlayer.selfBody.AddForce(new Vector2(0, 100));
        float yVelocity = -Mathf.Max(2, -(fallingPlayer.selfBody.velocity.y + 5));
        fallingPlayer.selfBody.velocity = new Vector2(fallingPlayer.selfBody.velocity.x, yVelocity);
        Debug.Log("woosh");
    }
}
