using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeartScript : MonoBehaviour {

    public PuzzleManager parent;
    public List<GameObject> hearts;
	
	// Update is called once per frame
	void Update () {
        if (parent != null)
        {
            for (int i = 0; i < hearts.Count; i++)
            {
                if (i < parent.remainingFailures)
                    hearts[i].SetActive(true);
                else
                    hearts[i].SetActive(false);
            }
        }
	}
}
