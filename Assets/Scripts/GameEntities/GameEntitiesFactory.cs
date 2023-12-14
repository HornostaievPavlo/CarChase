using UnityEngine;

public class GameEntitiesFactory : MonoBehaviour
{
    [Header("Obstacles")]
    [SerializeField] private GameObject[] obstaclesPrefabs;

    [SerializeField] private float obstaclesSpawningRate;

    [SerializeField] private GameObject policeCarPrefab;

    [Space]
    [Header("Boosters")]
    [SerializeField] private GameObject[] boostersPrefabs;

    [SerializeField] private float boostersSpawningRate;

    private const float VERTICAL_POSITION = 6f;
    private const float HORIZONTAL_SPAWN_BORDER = 1.25f;

    private void Start()
    {
        EventsHandler.LevelFailed.AddListener(DisableFactory);

        float timeBeforeNewPoliceCar = 60f;
        InvokeRepeating(nameof(SpawnPoliceCar), 10f, timeBeforeNewPoliceCar);

        float timeBeforeFirstObstacle = 5f;
        InvokeRepeating(nameof(SpawnRandomObstacle), timeBeforeFirstObstacle, obstaclesSpawningRate);

        float timeBeforeFirstBooster = 5f;
        InvokeRepeating(nameof(SpawnRandomBooster), timeBeforeFirstBooster, boostersSpawningRate);
    }

    private void DisableFactory()
    {
        Destroy(this);
    }

    private void SpawnRandomObstacle() => SelectRandomEntity(obstaclesPrefabs);

    private void SpawnRandomBooster() => SelectRandomEntity(boostersPrefabs);

    private void SelectRandomEntity(GameObject[] prefabs)
    {
        var randomEntity = prefabs[Random.Range(0, prefabs.Length)];

        var randomXPosition = Random.Range(-HORIZONTAL_SPAWN_BORDER, HORIZONTAL_SPAWN_BORDER);

        Vector3 position = new Vector3(randomXPosition, VERTICAL_POSITION, 0);

        var newBooster = Instantiate(randomEntity, transform);
        newBooster.transform.localPosition = position;

        newBooster.AddComponent<DownwardMovement>();
    }

    private void SpawnPoliceCar() => Instantiate(policeCarPrefab);
}
