﻿using UnityEngine;
using System.Collections;

public class SeeSaw : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<Rigidbody2D>().centerOfMass = Vector2.zero;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
