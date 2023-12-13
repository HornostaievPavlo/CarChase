using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private float oilSlowDownMultiplier = 0.75f;
    [SerializeField] private float oilSlowingDuration = 10f;
    [Space]
    [SerializeField] private float crackSlowDownMultiplier = 0.75f;
    [SerializeField] private float crackSlowingDuration = 5f;
    [SerializeField] private float crackDamageAmount = 25f;
    [Space]
    [SerializeField] private float nitroSpeedUpMultiplier = 2.0f;
    [SerializeField] private float nitroDuration = 15.0f;

    private PlayerMovement playerMovement;
    private PlayerPickupsHandler pickupsHandler;
    private PlayerHealth playerHealth;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        pickupsHandler = GetComponent<PlayerPickupsHandler>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleSolidObstacleCollision(collision);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandleTriggerCollision(collision);
    }

    private void HandleSolidObstacleCollision(Collision2D collision)
    {
        bool isObstacleHit = collision.gameObject.TryGetComponent(out Obstacle obstacle);

        if (isObstacleHit && pickupsHandler.currentPickup == PickupState.Shield)
        {
            Destroy(obstacle.gameObject);
            return;
        }

        if (isObstacleHit)
        {
            var obstacleType = obstacle.type;

            switch (obstacleType)
            {
                case ObstacleType.PoliceCar:
                    playerHealth.DamagePlayer(playerHealth.maxHealth);
                    break;

                case ObstacleType.Block:
                    playerHealth.DamagePlayer(playerHealth.maxHealth);
                    break;
            }
        }
    }

    private void HandleTriggerCollision(Collider2D collision)
    {
        bool isObstacleHit = collision.gameObject.TryGetComponent(out Obstacle obstacle);

        if (isObstacleHit)
        {
            ApplyObstacleEffect(obstacle);
            return;
        }

        bool isBoosterHit = collision.gameObject.TryGetComponent(out Booster booster);

        if (isBoosterHit)
        {
            ApplyBoosterEffect(booster);
            Destroy(collision.gameObject);
        }
    }

    private void ApplyObstacleEffect(Obstacle obstacle)
    {
        var obstacleType = obstacle.type;

        switch (obstacleType)
        {
            case ObstacleType.OilPuddle:
                StartCoroutine(playerMovement.ChangeMovementSpeed(oilSlowDownMultiplier, oilSlowingDuration));
                break;

            case ObstacleType.Crack:
                StartCoroutine(playerMovement.ChangeMovementSpeed(crackSlowDownMultiplier, crackSlowingDuration));
                playerHealth.DamagePlayer(crackDamageAmount);
                break;
        }
    }

    private void ApplyBoosterEffect(Booster booster)
    {
        var boosterType = booster.type;

        switch (boosterType)
        {
            case BoosterType.Coin:
                EventsHandler.OnCoinCollected();
                break;

            case BoosterType.Magnet:
                pickupsHandler.SetPickupState(PickupState.Magnet);
                break;

            case BoosterType.Shield:
                pickupsHandler.SetPickupState(PickupState.Shield);
                break;

            case BoosterType.Nitro:
                pickupsHandler.SetPickupState(PickupState.Nitro);
                playerMovement.ResetSpeed();
                StartCoroutine(playerMovement.ChangeMovementSpeed(nitroSpeedUpMultiplier, nitroDuration));
                break;

            case BoosterType.HealthPoint:
                EventsHandler.OnHealthPointCollected();
                break;
        }
    }
}
