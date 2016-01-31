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
        Debug.Log(col.gameObject.name);
        AppleBasin basin = col.gameObject.GetComponent<AppleBasin>();
        if (basin != null)
        {
            this.decaying = true;
            this.decayRate = basin.decayRate;
        }

        this.selfBody.velocity = Vector3.zero;
        this.selfBody.drag = 5.0f;
    }

    void Update()
    {
        if (decaying)
        {
            decayTime -= decayRate * Time.deltaTime;
            if (decayTime < 0)
                decaying = false;
        }
    }
}
