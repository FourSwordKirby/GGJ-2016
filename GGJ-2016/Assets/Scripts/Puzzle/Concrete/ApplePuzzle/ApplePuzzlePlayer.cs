using UnityEngine;
using System.Collections;

public class ApplePuzzlePlayer : MonoBehaviour {
    /*references to components*/
    private Animator anim;

    void Awake()
    {
        this.anim = this.GetComponent<Animator>();
    }

    public void trigger()
    {
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
}
