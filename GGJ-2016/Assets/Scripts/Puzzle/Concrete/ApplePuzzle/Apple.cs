using UnityEngine;
using System.Collections;

public class Apple : MonoBehaviour
{
    public float decayTime;
    public bool decaying;

    private float decayRate;

    /*references to components*/
    private Rigidbody2D selfBody;

    void Start()
    {
        decayRate = 0;
        selfBody = this.GetComponent<Rigidbody2D>();
    }

    public void Drop()
    {
        selfBody.isKinematic = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        AppleBasin basin = col.gameObject.GetComponent<AppleBasin>();
        if (basin != null)
        {
            this.decaying = true;
            this.decayRate = basin.decayRate;
        }

        this.selfBody.velocity = Vector3.zero;
        this.selfBody.drag = 18.0f;
		this.transform.parent.parent.GetComponent<ApplePuzzle> ().splashSound.Play ();
    }

    void Update()
    {
        if (decaying)
        {
            SpriteRenderer selfSprite = this.GetComponent<SpriteRenderer>();
            selfSprite.color = new Color(1.0f, decayTime / 1, decayTime / 1, decayTime / 1);
            decayTime -= decayRate * Time.deltaTime;
            if (decayTime < 0)
                decaying = false;
        }
    }
}
