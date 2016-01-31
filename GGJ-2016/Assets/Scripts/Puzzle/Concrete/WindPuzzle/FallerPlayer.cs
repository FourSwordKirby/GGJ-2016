using UnityEngine;
using System.Collections;

public class FallerPlayer : MonoBehaviour
{
    public enum PlayerAssignment
    {
        P1,
        P2
    }
    public PlayerAssignment assignment;

    public enum PlayerStatus
    {
        READY,
        WAITING,
        PRIMED,
        FAILED
    }
    public PlayerStatus playerStatus { get; private set; }

    /*references to components*/
    public Animator anim;
    public Rigidbody2D selfBody;

    void Awake()
    {
        this.anim = this.GetComponent<Animator>();
        this.selfBody = this.GetComponent<Rigidbody2D>();
    }

    public void steer(Vector2 direction)
    {
        this.transform.position += new Vector3(direction.x, direction.y, 0);
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
    }
}
