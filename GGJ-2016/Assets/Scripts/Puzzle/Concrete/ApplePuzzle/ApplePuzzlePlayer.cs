using UnityEngine;
using System.Collections;

public class ApplePuzzlePlayer : MonoBehaviour {

    public enum PlayerStatus
    {
        READY,
        WAITING,
        PRIMED,
        FAILED
    }
    public PlayerStatus playerStatus { get; private set; }
    public Apple apple;

    /*references to components*/
    private Animator anim;

    void Awake()
    {
        this.anim = this.GetComponent<Animator>();
    }

    public void trigger()
    {
        apple.Drop();
        this.playerStatus = PlayerStatus.WAITING;
        anim.SetTrigger("Release");
    }

    public void succeed()
    {
        //anim.SetTrigger("Succeed");
    }

    public void fail()
    {
        //anim.SetTrigger("Succeed");
    }

    void Update()
    {
        if (apple.decaying)
        {
            playerStatus = PlayerStatus.PRIMED;
        }
        if (apple.decayTime < 0)
        {
            playerStatus = PlayerStatus.FAILED;
        }
    }
}
