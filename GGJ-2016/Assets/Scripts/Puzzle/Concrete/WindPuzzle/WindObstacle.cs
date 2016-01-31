using UnityEngine;
using System.Collections;

public class WindObstacle : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        FallerPlayer player = col.gameObject.GetComponent<FallerPlayer>();
        if (player != null)
        {
            player.selfBody.velocity = new Vector2(player.selfBody.velocity.x / 2, 0);
        }
    }
}
