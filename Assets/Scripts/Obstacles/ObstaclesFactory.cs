using System.Collections.Generic;
using UnityEngine;

public class ObstaclesFactory : MonoBehaviour
{
    [SerializeField]
    private GameObject[] obstaclesPrefabs;

    [SerializeField]
    private GameObject policeCarPrefab;

    [SerializeField]
    private int maxObstaclesAmount;

    [SerializeField]
    private float obstaclesSpawningRate;

    private List<GameObject> obstacles = new List<GameObject>();

    private const float POLICE_SPAWN_RATE = 60f;

    private const float VERTICAL_POSITION = 6f;
    private const float HORIZONTAL_SPAWN_BORDER = 1.1f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnPoliceCar), POLICE_SPAWN_RATE, POLICE_SPAWN_RATE);

        float timeBeforeFirstObstacle = 5f;
        InvokeRepeating(nameof(SpawnRandomObstacle), timeBeforeFirstObstacle, obstaclesSpawningRate);
    }

    private void SpawnRandomObstacle()
    {
        var randomObstacle = obstaclesPrefabs[Random.Range(0, obstaclesPrefabs.Length)];

        var randomXPosition = Random.Range(-HORIZONTAL_SPAWN_BORDER, HORIZONTAL_SPAWN_BORDER);

        Vector3 position = new Vector3(randomXPosition, VERTICAL_POSITION, 0);

        var newObstacle = Instantiate(randomObstacle, transform);
        newObstacle.transform.localPosition = position;

        var obstacleMovement = newObstacle.AddComponent<DownwardMovement>();
        obstacleMovement.movementSpeed = 3f;

        obstacles.Add(newObstacle);
    }

    private void SpawnPoliceCar() => Instantiate(policeCarPrefab);
}
