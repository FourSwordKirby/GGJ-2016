using UnityEngine;
using System.Collections;

public class DrumPuzzlePlayer : MonoBehaviour {
    public float penalty;
    private float penaltyTimer;

    public enum PlayerStatus
    {
        IDLE,
        PRIMED,
        SUCCESS,
        PENALIZED,
        RECOVERING
    }
    public PlayerStatus playerStatus { get; private set; }
    public void determineIfPenalized()
    {
        if (playerStatus != PlayerStatus.SUCCESS)
        {
            playerStatus = PlayerStatus.PENALIZED;
        }
    }


    /*references to components*/
    private Animator anim;

    void Awake()
    {
        playerStatus = PlayerStatus.IDLE;

        this.anim = this.GetComponent<Animator>();
    }

    public void trigger()
    {
        anim.SetTrigger("Hit");
    }

    public void succeed()
    {
        playerStatus = PlayerStatus.SUCCESS;
        anim.SetTrigger("Succeed");
    }

    public void penalize()
    {
        playerStatus = PlayerStatus.RECOVERING;
        penaltyTimer = penalty;
        anim.SetBool("Penalized", true);
    }

    public void Update()
    {
        if (penaltyTimer > 0)
        {
            penaltyTimer -= Time.deltaTime;
            if (penaltyTimer <= 0)
            {
                playerStatus = PlayerStatus.IDLE;
                anim.SetBool("Penalized", false);
            }
        }
    }
}
