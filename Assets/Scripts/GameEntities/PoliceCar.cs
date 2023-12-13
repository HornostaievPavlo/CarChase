using UnityEngine;

public class PoliceCar : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    private Transform player;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    private void Update() => MoveTowardsPlayer();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool isPlayerHit = collision.gameObject.TryGetComponent(out PlayerMovement player);

        if (!isPlayerHit)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) => Destroy(gameObject);

    private void MoveTowardsPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position,
                                                 player.position,
                                                 movementSpeed * Time.deltaTime);
    }
}
