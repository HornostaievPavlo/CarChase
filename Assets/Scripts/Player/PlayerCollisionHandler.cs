using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    private PlayerMovement playerMovement;
    //private Booster booster;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        //booster = GetComponent<Booster>();
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

        //if (isObstacleHit && booster.type == BoosterType.Shield)
        //{
        //    Destroy(obstacle.gameObject);
        //    return;
        //}

        if (isObstacleHit)
        {
            var obstacleType = obstacle.type;

            switch (obstacleType)
            {
                case ObstacleType.PoliceCar:

                    playerMovement.StopMovement();

                    break;

                case ObstacleType.Block:

                    playerMovement.StopMovement();

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

                    break;

                case BoosterType.Magnet:

                    break;

                case BoosterType.Shield:

                    break;

                case BoosterType.Nitro:

                    break;

                case BoosterType.HealthPoint:

                    break;
            }

            Destroy(collision.gameObject);
        }
    }
}
