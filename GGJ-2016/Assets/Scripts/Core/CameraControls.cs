using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class CameraControls : MonoBehaviour {

    private Camera cameraComponent;

    public GameObject target;

    /* camera moving constants */
    private const float Z_OFFSET = -10.0f;

    /* A bunch of stuff that relates to how the camera shakes*/
    public enum ShakePresets
    {
        NONE,
        BOTH,
        HORIZONTAL,
        VERTICAL
    };
    private float shakeIntensity = 0.0f;
    private float shakeDuration = 0.0f;
    private ShakePresets shakeDirection = ShakePresets.NONE;
    private Action shakeComplete = null;
    private Vector2 shakeOffset = new Vector2();

    /*CONSTANTS*/
    private const float PAN_SPEED = 5.0f;

	// Use this for initialization
	void Start () {
        cameraComponent = GetComponent<Camera>();
	}
	
	void FixedUpdate () {
        //Do shake calculations
        if (shakeDuration > 0)
        {
            shakeDuration -= Time.deltaTime;
            if (shakeDuration <= 0)
                stopShaking();
            else
                applyShake();
        }

        //Following a target
        //Now follow the target
        Debug.Log("Offset" + new Vector3(0, 0, Z_OFFSET));
        Debug.Log("targetting pos" + target.transform.position + new Vector3(0, 0, Z_OFFSET));
        Debug.Log("my pos" + transform.position);
        if (target != null && transform.position != target.transform.position + new Vector3(0, 0, Z_OFFSET))
        {
            float x = ((target.transform.position + new Vector3(0, 0, Z_OFFSET)) - transform.position).x;
            float y = ((target.transform.position + new Vector3(0, 0, Z_OFFSET)) - transform.position).y;
            GetComponent<Rigidbody2D>().velocity = new Vector2(x * PAN_SPEED, y * PAN_SPEED);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity.Set(0.0f, 0.0f);
        }
	}

    public void Shake(float Intensity = 0.05f, 
                        float Duration = 0.5f, 
                        Action OnComplete = null, 
                        bool Force = true, 
                        ShakePresets Direction = ShakePresets.NONE)
    {
        if(!Force && ((shakeOffset.x != 0) || (shakeOffset.y != 0)))
			return;
		shakeIntensity = Intensity;
		shakeDuration = Duration;
        shakeComplete = OnComplete;
		shakeDirection = Direction;
        shakeOffset.Set(0, 0);
    }

    public void Target(GameObject target)
    {
        this.target = target;
        this.gameObject.transform.position = target.transform.position + new Vector3(0, 0, Z_OFFSET);
    }

    private void stopShaking()
    {
        shakeOffset.Set(0, 0);
        if (shakeComplete != null)
            shakeComplete();
    }

    private void applyShake()
    {
        if (shakeDirection == ShakePresets.BOTH || shakeDirection == ShakePresets.HORIZONTAL)
                    shakeOffset.x = (UnityEngine.Random.Range(-1.0F, 1.0F) * shakeIntensity);
        if (shakeDirection == ShakePresets.BOTH || shakeDirection == ShakePresets.VERTICAL)
              shakeOffset.y = (UnityEngine.Random.Range(-1.0F, 1.0F) * shakeIntensity);

        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;

        transform.position = new Vector3(x + shakeOffset.x, y + shakeOffset.y, z);
    }
}
