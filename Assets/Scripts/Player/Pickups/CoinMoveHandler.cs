using UnityEngine;

public class CoinMoveHandler : MonoBehaviour
{
    private PlayerPickupsHandler player;

    private void Start()
    {
        player = FindObjectOfType<PlayerPickupsHandler>();
    }

    private void Update()
    {
        if (player.currentPickup != PickupState.Magnet)
            return;

        MoveTowardsPlayer();
    }

    private void MoveTowardsPlayer()
    {
        float movementSpeed = 2f;

        transform.position = Vector3.MoveTowards(transform.position,
                                                 player.transform.position,
                                                 movementSpeed * Time.deltaTime);
    }
}
