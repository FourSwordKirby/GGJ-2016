using UnityEngine;
using System.Collections;

public class FadeAndDestroy : MonoBehaviour {

    public float FadeTime = 1.0f;

    private float timeRemaining;

    private SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
        timeRemaining = FadeTime;
        sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(timeRemaining > 0.0f)
        {
            timeRemaining -= Time.deltaTime;
            sprite.color = new Color(1.0f, 1.0f, 1.0f, timeRemaining / FadeTime);
        }
        else
        {
            Destroy(this.gameObject);
        }
	}
}
