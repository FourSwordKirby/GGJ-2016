using UnityEngine;
using System.Collections;

public class SetupScript : MonoBehaviour {


	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.F1))
        {
            Screen.SetResolution(3800, 1000, false);
        }
	}
}
