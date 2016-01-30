using UnityEngine;
using System.Collections;

public class DrumPuzzlePlayer : MonoBehaviour {
    public float leniency;
    private float leniencyTimer;

    public float penalty;
    private float penaltyTimer;

    void Awake()
    {
        leniencyTimer = 0;
        penaltyTimer = 0;
    }

    public void trigger()
    {
        if (leniencyTimer <= 0)
        {
            leniencyTimer = leniency;
        }
    }

    public void succeed()
    {
        leniencyTimer = 0;
    }

    public bool isReady()
    {
        return (leniencyTimer > 0);
    }

    public bool isStunned()
    {
        return (penaltyTimer > 0);
    }

    void Update()
    {
        if (leniencyTimer > 0)
        {
            leniencyTimer -= Time.deltaTime;
            if (leniencyTimer <= 0)
            {
                penaltyTimer = penalty;
            }
        }

        if (penaltyTimer > 0)
        {
            penaltyTimer -= Time.deltaTime;
            if (penaltyTimer <= 0)
            {
                penaltyTimer = 0;
            }
        }
    }


}
