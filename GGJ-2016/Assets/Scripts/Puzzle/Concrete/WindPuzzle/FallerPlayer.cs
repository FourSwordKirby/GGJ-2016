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

    public float steeringAbility;
    public float maxAcceleration;
    public float terminalVelocity;

    public GameObject cameraPosition;

    private float idealDrag;

    /*references to components*/
    public Animator anim;
    public Rigidbody2D selfBody;
    public Collider2D colBody;

    void Awake()
    {
        this.anim = this.GetComponent<Animator>();
        this.selfBody = this.GetComponent<Rigidbody2D>();
        this.colBody = this.GetComponent<Collider2D>();

        idealDrag = maxAcceleration / terminalVelocity;
        selfBody.drag = idealDrag / (idealDrag * Time.fixedDeltaTime + 1);
    }

    public void steer(Vector2 direction)
    {
        this.selfBody.AddForce(new Vector2(direction.x * steeringAbility, 0));
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

    public GameObject GetTarget()
    {
        return cameraPosition;
    }
}
