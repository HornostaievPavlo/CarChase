using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float horizontalSpeed;

    [SerializeField]
    private float verticalSpeed;

    private Rigidbody2D rb;

    private void Awake() => rb = GetComponent<Rigidbody2D>();

    private void FixedUpdate()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        float newXPosition = rb.position.x + horizontalInput * horizontalSpeed * Time.fixedDeltaTime;
        float newYPosition = rb.position.y + verticalInput * verticalSpeed * Time.fixedDeltaTime;

        rb.MovePosition(new Vector2(newXPosition, newYPosition));
    }
}
