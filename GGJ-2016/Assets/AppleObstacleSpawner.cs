using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AppleObstacleSpawner : MonoBehaviour {

    public GameObject obstaclePrefab;

    public List<GameObject> spawnLocations;
    public float rotationLowerRange;
    public float rotationUpperRange;

    public int obstacleCount;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < obstacleCount; i++)
        {
            GameObject cloud = Instantiate(obstaclePrefab);
            int locationIndex = Random.Range(0, spawnLocations.Count);
            cloud.transform.position = spawnLocations[locationIndex].transform.position;
            if(cloud.transform.position.x <= 0)
                cloud.transform.Rotate(Random.Range(rotationLowerRange, rotationUpperRange), 0.0f, 0.0f);
            else
                cloud.transform.Rotate(-Random.Range(rotationLowerRange, rotationUpperRange), 0.0f, 0.0f);

            spawnLocations.RemoveAt(locationIndex);

            cloud.transform.parent = this.gameObject.transform;
        }
    }
}
