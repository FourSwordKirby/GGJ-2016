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

    void Start()
    {
        TransitionManager.Instance.SetScreenEmpty();
    }

    void Update()
    {
        if (player1.col.IsTouching(player2.col))
        {
            player1.gameObject.layer = LayerMask.NameToLayer("Default");
            player2.gameObject.layer = LayerMask.NameToLayer("Default");
            if (Mathf.Abs(player1.transform.position.y - player2.transform.position.y) <= 0.2f && player1.transform.position.x < player2.transform.position.x)
            {
                player1.enabled = false;
                player2.enabled = false;
                TransitionManager.Instance.FadeToWhite(() => Application.LoadLevel("PlaytestScene"));
                transitionGuard = true;
            }
        }
        else
        {
            player1.gameObject.layer = LayerMask.NameToLayer("P1 ONLY");
            player2.gameObject.layer = LayerMask.NameToLayer("P2 ONLY");
        }
    }
}
