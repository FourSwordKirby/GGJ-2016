using UnityEngine;
using System.Collections;

public class WindObstacle : MonoBehaviour {

    private float oldDrag;

    void OnTriggerEnter2D(Collider2D col)
    {
        FallerPlayer player = col.gameObject.GetComponent<FallerPlayer>();
        if (player != null)
        {
            player.selfBody.velocity = new Vector2(player.selfBody.velocity.x / 2, 0);
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        FallerPlayer player = col.gameObject.GetComponent<FallerPlayer>();
        if (player != null)
        {
            player.selfBody.drag = 1.0f;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        FallerPlayer player = col.gameObject.GetComponent<FallerPlayer>();
        if (player != null)
        {
            player.selfBody.drag = 0.0f;
        }
    }
}
