using UnityEngine;

public class ObstaclesFactory : MonoBehaviour
{
    [SerializeField]
    private GameObject[] obstaclesPrefabs;

    [SerializeField]
    private GameObject policeCarPrefab;

    [SerializeField]
    private Transform obstaclesParent;

    private const float POLICE_SPAWN_RATE = 60.0f;

    private const float VERTICAL_UPPER_POSITION = -50.0f;
    private const float VERTICAL_LOWER_POSITION = -20.0f;
    private const float HORIZONTAL_SPAWN_BORDER = 3.5f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnPoliceCar), POLICE_SPAWN_RATE, POLICE_SPAWN_RATE);
    }

    private void SpawnRandomObstacle()
    {
        var randomObstacle = obstaclesPrefabs[Random.Range(0, obstaclesPrefabs.Length)];

        var randomXPosition = Random.Range(-HORIZONTAL_SPAWN_BORDER, HORIZONTAL_SPAWN_BORDER);
        var randomYPosition = Random.Range(VERTICAL_UPPER_POSITION, VERTICAL_LOWER_POSITION);

        Vector3 position = new Vector3(randomXPosition, randomYPosition, 0);

        var newObstacle = Instantiate(randomObstacle, obstaclesParent);
        newObstacle.transform.localPosition = position;
    }

    private void SpawnPoliceCar() => Instantiate(policeCarPrefab);
}
