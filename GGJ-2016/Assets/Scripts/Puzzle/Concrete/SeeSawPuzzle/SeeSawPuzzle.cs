using UnityEngine;
using System.Collections;

public class SeeSawPuzzle : Puzzle {

    private const string PUZZLE_NAME = "See Saw Puzzle";
    private const int DIFFICULTY = 1;
    private const float TIME_LIMIT = 7.0f;
    private const float PLAYER_SPEED = 12.0f;
    private const float AREA_X_MIN = 1.0f;
    private const float AREA_X_MAX = 3.7f;
    private const float DEAD_ZONE_Y = -7.0f;

    public bool tutorialMode = false;

    private float timeRemaining;
    private Vector2 p1Dir;
    private Vector2 p1Vel;
    private Vector2 p2Dir;
    private Vector2 p2Vel;
    private Vector3 oldCam1Pos;
    private Vector3 oldCam2Pos;
    private bool good;
    private bool playerDied;
    private PuzzleStatus status;

    private Vector3 camPosition;
    private Camera cam1;
    private Camera cam2;
    private Weight leftWeight;
    private Rigidbody2D leftBody;
    private Weight rightWeight;
    private Rigidbody2D rightBody;
    private Rigidbody2D seeSawBody;
    

    public override void Setup()
    {
        timeRemaining = TIME_LIMIT;
        good = true;
        playerDied = false;
        status = PuzzleStatus.INPROGRESS;

        // Generates the "solution"
        // Need left torque = right torque
        float leftLoc = -Random.Range(AREA_X_MIN, AREA_X_MAX);
        float leftMass = 10.0f;
        float rightLoc = Random.Range(AREA_X_MIN, AREA_X_MAX);
        float rightMass = -leftLoc * leftMass / rightLoc;

        // Generates spawn points
        float leftSpawn =  -(AREA_X_MAX + AREA_X_MIN) / 2;//-Random.Range(AREA_X_MIN, AREA_X_MAX);
        float rightSpawn =  (AREA_X_MAX + AREA_X_MIN) / 2;// Random.Range(AREA_X_MIN, AREA_X_MAX);

        // Player 1 is on the left... for now.
        leftWeight = this.transform.FindChild("Left Weight").GetComponent<Weight>();
        leftBody = leftWeight.GetComponent<Rigidbody2D>();
        leftBody.position = new Vector2(leftSpawn, leftBody.position.y);
        leftBody.mass = leftMass;

        // Player 2
        rightWeight = this.transform.FindChild("Right Weight").GetComponent<Weight>();
        rightBody = rightWeight.GetComponent<Rigidbody2D>();
        rightBody.position = new Vector2(rightSpawn, rightBody.position.y);
        rightBody.mass = rightMass;

        // Adjust camera.
        // Save camera positions then move both to our camera point.
        camPosition = this.transform.FindChild("Camera Point").position;
        cam1 = GameObject.Find("P1 Camera").GetComponent<Camera>();
        Debug.Log("Cam position" + cam1.transform.position);
        oldCam1Pos = cam1.transform.position;
        cam1.transform.position = camPosition;
        cam2 = GameObject.Find("P2 Camera").GetComponent<Camera>();
        oldCam2Pos = cam2.transform.position;
        cam2.transform.position = camPosition;

        seeSawBody = this.transform.FindChild("SeeSaw Board").GetComponent<Rigidbody2D>();
        if(tutorialMode)
        {
            leftBody.mass = 10.0f;
            rightBody.mass = 11.0f;
            seeSawBody.angularDrag = 1;//1000000.0f;
        }
    }

    public override void Cleanup()
    {
        // Restore cameras
        Debug.Log("Restoring cams");
        cam1.transform.position = oldCam1Pos;
        cam2.transform.position = oldCam2Pos;
    }

    public override void Execute()
    {
        if(timeRemaining >= 0.0f)
        {
            timeRemaining -= Time.deltaTime;

            if(leftBody.position.y < DEAD_ZONE_Y || rightBody.position.y < DEAD_ZONE_Y)
            {
                status = PuzzleStatus.FAIL;
            }

            if(timeRemaining < 0.0f)
            {
                timeRemaining = 0.0f;
                if(good)
                {
                    status = PuzzleStatus.SUCCESS;
                }
                else
                {
                    status = PuzzleStatus.FAIL;
                }
            }
        }
        else
        {
            // ????
        }
    }

    public override void FixedExecute()
    {
        Vector2 vel;
        Vector2 rotatedP1Dir = (Vector2)(Quaternion.Euler(0.0f, 0.0f, leftBody.rotation) * p1Dir);
        vel = leftBody.velocity;
        vel += (rotatedP1Dir) * PLAYER_SPEED * Time.deltaTime;
        vel.x = Mathf.Clamp(vel.x, -PLAYER_SPEED, PLAYER_SPEED);
        leftBody.velocity = vel;

        Vector2 rotatedP2Dir = (Vector2)(Quaternion.Euler(0.0f, 0.0f, leftBody.rotation) * p2Dir);
        vel = rightBody.velocity;
        vel += rotatedP2Dir * PLAYER_SPEED * Time.deltaTime;
        vel.x = Mathf.Clamp(vel.x, -PLAYER_SPEED, PLAYER_SPEED);
        rightBody.velocity = vel;
    }

    public override PuzzleStatus Status()
    {
        return status;
    }

    public override float GetTimeRemaining()
    {
        return timeRemaining;
    }

    public override float GetTimeLimit()
    {
        return TIME_LIMIT;
    }

    public override int GetDifficulty()
    {
        return DIFFICULTY;
    }

    public override string GetName()
    {
        return PUZZLE_NAME;
    }

    public override void P1_Direction(Vector2 dir)
    {
        Debug.Log("P1 Dir is " + dir);
        p1Dir = new Vector2(dir.x, 0.0f);
    }

    public override void P2_Direction(Vector2 dir)
    {
        p2Dir = new Vector2(dir.x, 0.0f);
    }

    public void BadState()
    {
        good = false;
    }

    public void GoodState()
    {
        good = true;
    }

    public void Dead()
    {
        good = false;
        playerDied = true;
    }
}
