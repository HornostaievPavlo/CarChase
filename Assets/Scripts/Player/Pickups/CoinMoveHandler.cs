using UnityEngine;

public class CoinMoveHandler : MonoBehaviour
{
    public float movementSpeed;

    private PlayerPickupsHandler player;

    private void Start()
    {
        player = FindObjectOfType<PlayerPickupsHandler>();
    }

    private void Update()
    {
        if (player.currentPickup != PickupState.Magnet) return;

        MoveTowardsPlayer();
    }

    private void MoveTowardsPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position,
                                                 player.transform.position,
                                                 movementSpeed * Time.deltaTime);
    }
}
