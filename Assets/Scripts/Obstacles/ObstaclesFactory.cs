using UnityEngine;

public class ObstaclesFactory : MonoBehaviour
{
    [SerializeField]
    private GameObject[] obstaclesPrefabs;

    [SerializeField]
    private GameObject policeCarPrefab;

    [SerializeField]
    private Transform spawnPosition;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) SpawnObstacle();
    }

    private void SpawnObstacle()
    {
        var obstacle = Instantiate(policeCarPrefab);
    }
}
