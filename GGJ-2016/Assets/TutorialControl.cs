using UnityEngine;
using System.Collections;

public class TutorialControl : MonoBehaviour {
    public int playerIndex;

    public Collider2D col;
    public Rigidbody2D selfBody;

    void Start()
    {
        col = this.GetComponent<Collider2D>();
        selfBody = this.GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
	void Update () {
        Vector2 dirVector = Controls.GetDirection(playerIndex);
        Vector2 trueDirVector = new Vector2(dirVector.x, -dirVector.y);
        this.selfBody.velocity += trueDirVector * 0.2f;
	}
}
