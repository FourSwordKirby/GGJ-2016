using UnityEngine;
using System.Collections;

public class IntroMusic : MonoBehaviour {

	// Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
	}
}
