using UnityEngine;

public class PoliceCar : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    public Transform player;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    private void Update()
    {
        MoveTowardsPlayer();
    }

    private void MoveTowardsPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position,
                                        player.position,
                                        movementSpeed * Time.deltaTime);
    }
}
