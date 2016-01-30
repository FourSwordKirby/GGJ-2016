using UnityEngine;
using System.Collections;

public class BadSpace : MonoBehaviour {

    private Color goodColor = new Color(0, 255.0f / 256, 12.0f / 256, 85.0f / 256);
    private Color badColor = new Color(184.0f / 256, 0, 0, 85.0f / 256);

    private SeeSawPuzzle puzzle;
    private SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
        puzzle = transform.GetComponentInParent<SeeSawPuzzle>();
        sprite = this.GetComponent<SpriteRenderer>();
        sprite.color = goodColor;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("TRIGGERED");
        if(other.GetComponentInParent<SeeSaw>() != null)
        {
            puzzle.BadState();
            sprite.color = badColor;
        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponentInParent<SeeSaw>() != null)
        {
            puzzle.GoodState();
            sprite.color = goodColor;
        }
    }
}
