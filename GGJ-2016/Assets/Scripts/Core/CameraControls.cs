using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class CameraControls : MonoBehaviour {

    private Camera cameraComponent;

    public float zoomSpeed = 20f;
    public float maxZoomFOV = 10f;

    /* camera moving constants */
    private const float Z_OFFSET = -10;

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
