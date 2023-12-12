using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerBooster booster;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        booster = GetComponent<PlayerBooster>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool isObstacleHit = collision.gameObject.TryGetComponent(out Obstacle obstacle);

        if (isObstacleHit && booster.type == BoosterType.Shield)
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

                    break;

                case ObstacleType.Block:

                    playerMovement.StopMovement();

                    break;
            }
        }
    }
}
