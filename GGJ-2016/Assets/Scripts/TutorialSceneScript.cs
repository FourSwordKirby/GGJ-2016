using UnityEngine;
using System.Collections;

public class TutorialSceneScript : MonoBehaviour {
    public TutorialControl player1;
    public TutorialControl player2;

    private bool transitionGuard;

    void Awake()
    {
        transitionGuard = false;
    }

    void Update()
    {
        if (player1.col.bounds.Intersects(player2.col.bounds) && !transitionGuard)
        {
            TransitionManager.Instance.FadeToWhite(() => Application.LoadLevel("PlaytestScene"));
            transitionGuard = true;
        }
    }
}
