using UnityEngine;
using System.Collections;

public class IntroMusic : MonoBehaviour {

    private static IntroMusic instance; 
    public static IntroMusic GetInstance() { return instance; }
 

	// Use this for initialization
    void Awake()
    {
        if (instance != null && instance != this) 
        {
            Destroy(this.gameObject); 
            return; 
        } 
        else 
        {
            instance = this; 
        } 
        DontDestroyOnLoad(this.gameObject);
	}
}
