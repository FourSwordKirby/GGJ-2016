using UnityEngine;
using System.Collections;

public class FallerPlayer : MonoBehaviour
{
    public Color P1Color;
    public Color P2Color;

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


    private float steerModifier;
    private float idealDrag;

    /*references to components*/
    public Animator anim;
    public Rigidbody2D selfBody;
    public Collider2D colBody;
    private SpriteRenderer sprite;
    private SpriteRenderer arrow;
    private Transform catcher;

    void Start()
    {
        this.anim = this.GetComponent<Animator>();
        this.selfBody = this.GetComponent<Rigidbody2D>();
        this.colBody = this.GetComponent<Collider2D>();
        sprite = this.transform.FindChild("Sprite").GetComponent<SpriteRenderer>();
        arrow = this.transform.FindChild("Arrow").GetComponent<SpriteRenderer>();
        catcher = this.transform.parent.FindChild("Catcher").transform;

        steerModifier = 1.0f;
        idealDrag = maxAcceleration / terminalVelocity;
        idealDrag = idealDrag / (idealDrag * Time.fixedDeltaTime + 1);
        selfBody.drag = idealDrag;
    }

    public void steer(Vector2 direction)
    {
        this.selfBody.AddForce(new Vector2(direction.x * steeringAbility * steerModifier, 0));
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
        steerModifier = 1.0f - Mathf.Abs(this.selfBody.velocity.y / terminalVelocity);
        if(assignment == PlayerAssignment.P1)
        {
            sprite.color = P1Color;
            arrow.color = P2Color;
        }
        else
        {
            sprite.color = P2Color;
            arrow.color = P1Color;
        }
        Vector3 fakePos = new Vector3(this.transform.position.x, catcher.position.y + 5.0f, 0.0f);
        Vector3 dir = (catcher.position - fakePos).normalized * 2.0f;
        arrow.transform.rotation = Quaternion.FromToRotation(Vector3.down, dir.normalized);
        arrow.transform.position = this.transform.position + dir;
    }

    public GameObject GetTarget()
    {
        return cameraPosition;
    }
}
