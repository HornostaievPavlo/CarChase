using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerPickupsHandler pickupsHandler;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        pickupsHandler = GetComponent<PlayerPickupsHandler>();
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
                    playerMovement.StopMovement();
                    EventsHandler.OnLevelFailed();
                    break;

                case ObstacleType.Block:
                    playerMovement.StopMovement();
                    EventsHandler.OnLevelFailed();
                    break;
            }
        }
    }

    private void HandleTriggerCollision(Collider2D collision)
    {
        bool isObstacleHit = collision.gameObject.TryGetComponent(out Obstacle obstacle);

        if (isObstacleHit)
        {
            var obstacleType = obstacle.type;

            switch (obstacleType)
            {
                case ObstacleType.OilPuddle:

                    float oilSlowingDuration = 10f;
                    playerMovement.SlowMovement(oilSlowingDuration);
                    break;

                case ObstacleType.Crack:

                    float crackSlowingDuration = 5f;
                    playerMovement.SlowMovement(crackSlowingDuration);

                    break;
            }

            return;
        }

        bool isBoosterHit = collision.gameObject.TryGetComponent(out Booster booster);

        if (isBoosterHit)
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
                    break;

                case BoosterType.HealthPoint:
                    EventsHandler.OnHealthPointCollected();
                    break;
            }

            Destroy(collision.gameObject);
        }
    }
}
