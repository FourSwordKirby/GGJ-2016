using UnityEngine;
using System.Collections;

public class WindObstacleSpawner : MonoBehaviour {

    public GameObject obstaclePrefab;
    public float xLowerRange;
    public float yLowerRange;
    public float xUpperRange;
    public float yUpperRange;

    public int obstacleCount;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < obstacleCount; i++)
        {
            GameObject cloud = Instantiate(obstaclePrefab);
            float xPos = Random.RandomRange(xLowerRange, xUpperRange);
            float yPos = Random.RandomRange(yLowerRange, yUpperRange);
            cloud.transform.position = new Vector3(xPos, yPos, 0);
            cloud.transform.parent = this.gameObject.transform;
        }
	}
}
