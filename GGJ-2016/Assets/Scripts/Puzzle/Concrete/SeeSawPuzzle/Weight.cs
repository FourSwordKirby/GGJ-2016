using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Weight : MonoBehaviour {

    public bool debug = false;

    private float mass;

    private Rigidbody2D body;
    private Text text;
    private Animator anim;

	// Use this for initialization
	void Start () {
        body = this.GetComponent<Rigidbody2D>();
        text = this.GetComponentInChildren<Text>();
        anim = this.GetComponent<Animator>();
        Debug.Log("Text is " + text);
	}
	
	// Update is called once per frame
	void Update () {
        if(debug)
        {
            //text.enabled = true;
            text.text = "" + body.mass;
        }
        else
        {
            text.text = "";
            //text.enabled = false;
        }
        anim.SetFloat("Speed", Mathf.Abs(body.velocity.x));
        if(body.velocity.x > 0.2f)
        {
            this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        else if (body.velocity.x < -0.2f)
        {
            this.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
	}

    public void SetMass(float mass)
    {
        body.mass = mass;
    }
}
