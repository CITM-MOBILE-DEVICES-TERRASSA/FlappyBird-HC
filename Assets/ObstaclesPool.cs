using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesPool : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private int poolSize = 5;
    [SerializeField] private float spawnTime = 2.5f;
    [SerializeField] private float xSpawnPos = 12f;
    [SerializeField] private float minYPos = -2.5f;
    [SerializeField] private float maxYPos = 2.5f;

    private float timeSinceLastSpawn;
    private int obstacleCount;
    private GameObject[] obstacles;

    // Start is called before the first frame update
    void Start()
    {
        obstacles = new GameObject[poolSize];
        for(int i = 0; i < poolSize; i++)
        {
            obstacles[i] = Instantiate(obstaclePrefab, transform);
            obstacles[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime * GameManager.Instance.GetLevel();
        if(timeSinceLastSpawn >= spawnTime && !GameManager.Instance.isGameOver)
        {
            timeSinceLastSpawn = 0;
            SpawnObstacle();
        }
    }

    private void SpawnObstacle()
    {
        timeSinceLastSpawn = 0;

        float ySpawnPos = Random.Range(minYPos, maxYPos);
        obstacles[obstacleCount].transform.position = new Vector2(xSpawnPos, ySpawnPos);

        if(!obstacles[obstacleCount].activeInHierarchy)
        {
            obstacles[obstacleCount].SetActive(true);
        }
        obstacleCount++;

        if(obstacleCount >= poolSize)
        {
            obstacleCount = 0;
        }
    }
}
