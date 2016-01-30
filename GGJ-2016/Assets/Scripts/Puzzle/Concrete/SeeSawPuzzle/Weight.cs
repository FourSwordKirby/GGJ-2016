using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Weight : MonoBehaviour {

    public bool debug = false;

    private float mass;

    private Rigidbody2D body;
    private Text text;

	// Use this for initialization
	void Start () {
        body = this.GetComponent<Rigidbody2D>();
        text = this.GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if(debug)
        {
            text.gameObject.SetActive(true);
            text.text = "" + body.mass;
        }
        else
        {
            text.gameObject.SetActive(false);
        }
	}

    public void SetMass(float mass)
    {
        body.mass = mass;
    }
}
