using UnityEngine;

public class PoliceCar : MonoBehaviour
{
    private float movementSpeed = 2f;

    private Transform player;

    private void Start() => player = FindObjectOfType<PlayerMovement>().transform;

    private void Update() => MoveTowardsPlayer();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool isPlayerHit = collision.gameObject.TryGetComponent(out PlayerMovement player);

        if (isPlayerHit)
            movementSpeed = 0f;
        else
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) => movementSpeed *= 0.5f;

    private void MoveTowardsPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position,
                                                 player.position,
                                                 movementSpeed * Time.deltaTime);
    }
}
