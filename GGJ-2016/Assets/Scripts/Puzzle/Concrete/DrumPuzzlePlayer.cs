using UnityEngine;
using System.Collections;

public class DrumPuzzlePlayer : MonoBehaviour {
    public float leniency;
    private float leniencyTimer;

    public float penalty;
    private float penaltyTimer;

    /*references to components*/
    private Animator anim;

    void Awake()
    {
        leniencyTimer = 0;
        penaltyTimer = 0;

        this.anim = this.GetComponent<Animator>();
    }

    void Start()
    {
    }

    public void trigger()
    {
        if (leniencyTimer <= 0)
        {
            leniencyTimer = leniency;
            anim.SetTrigger("Hit");
        }
    }

    public void succeed()
    {
        leniencyTimer = 0;
        anim.SetTrigger("Succeed");
    }

    public bool isReady()
    {
        return (leniencyTimer >= 0);
    }

    public bool isStunned()
    {
        return (penaltyTimer > 0);
    }

    void Update()
    {
        if (leniencyTimer >= 0)
        {
            leniencyTimer -= Time.deltaTime;
            if (leniencyTimer < 0)
            {
                penaltyTimer = penalty;
                anim.SetBool("Penalized", true);
            }
        }

        if (penaltyTimer >= 0)
        {
            penaltyTimer -= Time.deltaTime;
            if (penaltyTimer < 0)
            {
                penaltyTimer = 0;
                anim.SetBool("Penalized", false);
            }
        }
    }
}
