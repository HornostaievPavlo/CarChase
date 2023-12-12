using UnityEngine;

public class ObstaclesFactory : MonoBehaviour
{
    [SerializeField]
    private GameObject[] obstaclesPrefabs;

    [SerializeField]
    private GameObject policeCarPrefab;

    [SerializeField]
    private Transform spawnPosition;

    private const float POLICE_SPAWN_RATE = 60.0f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), 1f, POLICE_SPAWN_RATE);
    }

    private void Update()
    {
    }

    private void SpawnObstacle()
    {
        var obstacle = Instantiate(policeCarPrefab);
    }
}
