using UnityEngine;
using System.Collections;

public class IntroSceneScript : MonoBehaviour {

    private bool transitionGuard = false;

    void Start()
    {
        TransitionManager.Instance.SetScreenEmpty();
    }

    // Update is called once per frame
	void Update ()
    {
        if (Controls.AInputDown(0) || Controls.AInputDown(1) ||
            Controls.BInputDown(0) || Controls.BInputDown(1))
        {
            Debug.Log("hello");
            sceneTransition();
        }
	}

    public void sceneTransition()
    {
        if (!transitionGuard)
        {
            TransitionManager.Instance.FadeToWhite(() => Application.LoadLevel("TitleScene"));
            transitionGuard = true;
        }
    }
}
