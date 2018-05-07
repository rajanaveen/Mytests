using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    public List<Transform> spawners;
    public List<Obstacle> obstacles;

    public float timeInterval = 1f;
    float nextSpawnTime = 0;

    private void Start()
    {
        GenerateNextSpawnTime();
    }

    void GenerateNextSpawnTime()
    {
        nextSpawnTime += timeInterval;
    }

    public void Update()
    {
        if (!VehicleController.detected)
        {
            return;
        }
        if (Time.time > nextSpawnTime)
        {
            StartCoroutine(SpawnObstacle());
            GenerateNextSpawnTime();
        }
    }

    public IEnumerator SpawnObstacle()
    {
        Obstacle rObstacle;
        do
        {
            rObstacle = null;
            int randIndex = Random.Range(0, obstacles.Count);
            if (!obstacles[randIndex].onRoad)
                rObstacle = obstacles[randIndex];
            yield return null;
        } while (rObstacle == null);
        int sIndex = Random.Range(0, spawners.Count);
        rObstacle.SelectRandomVehicle();
        rObstacle.transform.position = spawners[sIndex].position;
        rObstacle.transform.rotation = spawners[sIndex].rotation;
        rObstacle.onRoad = true;
    }
}
