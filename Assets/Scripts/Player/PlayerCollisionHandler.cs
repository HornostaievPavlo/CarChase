using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerPickupsHandler pickupsHandler;
    private PlayerHealth playerHealth;

    private float oilSlowDownMultiplier = 0.75f;
    private float oilSlowingDuration = 10f;

    private float crackSlowDownMultiplier = 0.75f;
    private float crackSlowingDuration = 5f;
    private float crackDamageAmount = 25f;

    private float nitroSpeedUpMultiplier = 2.0f;
    private float nitroDuration = 15.0f;

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

            if (obstacleType == ObstacleType.PoliceCar ||
                obstacleType == ObstacleType.Block)
            {
                playerHealth.DamagePlayer(playerHealth.maxHealth);
                EventsHandler.OnPlayerCrushed(collision.transform.position);
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
        else
        {
            var booster = collision.gameObject.GetComponent<Booster>();
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
                StartCoroutine(playerMovement.ChangeMovementSpeed
                    (oilSlowDownMultiplier, oilSlowingDuration));
                break;

            case ObstacleType.Crack:
                StartCoroutine(playerMovement.ChangeMovementSpeed
                    (crackSlowDownMultiplier, crackSlowingDuration));

                playerHealth.DamagePlayer(crackDamageAmount);
                EventsHandler.OnPlayerCrushed(transform.position);
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
                pickupsHandler.UpdatePickupVisual(PickupState.Magnet);
                break;

            case BoosterType.Shield:
                pickupsHandler.UpdatePickupVisual(PickupState.Shield);
                break;

            case BoosterType.Nitro:
                pickupsHandler.UpdatePickupVisual(PickupState.Nitro);
                playerMovement.ResetSpeed();
                StartCoroutine(playerMovement.ChangeMovementSpeed
                    (nitroSpeedUpMultiplier, nitroDuration));
                break;

            case BoosterType.HealthPoint:
                EventsHandler.OnHealthPointCollected();
                break;
        }
    }
}
