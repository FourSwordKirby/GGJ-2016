using UnityEngine;
using System.Collections;

public class TitleSceneScript : MonoBehaviour {

    private bool transitionGuard = false;

    private float loopTimer = 20;

    private float P1_Leeway = 0.05f;
    private float P2_Leeway = 0.05f;

    private float P1_timer = 0;
    private float P2_timer = 0;

    private bool isTutorialP1;
    private bool isTutorialP2;

    void Start()
    {
        TransitionManager.Instance.SetScreenEmpty();
    }

	void Update ()
    {
        if (Controls.AInputDown(0) && P1_timer <= 0)
        {
            P1_timer = P1_Leeway;
        }
        if (Controls.BInputDown(1) && P2_timer <= 0)
        {
            P2_timer = P2_Leeway;
        }

        if (P1_timer > 0 && P2_timer > 0 && !transitionGuard)
        {
            TransitionManager.Instance.FadeToDark(() => Application.LoadLevel("TutorialScene"));
            transitionGuard = true;
        }

        if (loopTimer <= 0 && !transitionGuard)
        {
            TransitionManager.Instance.FadeToWhite(() => Application.LoadLevel("IntroScene"));
            transitionGuard = true;
        }

        if (P1_timer > 0)
            P1_timer -= Time.deltaTime;
        if (P2_timer > 0)
            P2_timer -= Time.deltaTime;
        if (loopTimer > 0)
            loopTimer -= Time.deltaTime;
    }
}
