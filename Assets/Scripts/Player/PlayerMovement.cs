using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float horizontalSpeed;

    [SerializeField]
    private float verticalSpeed;

    private Rigidbody2D rb;

    private float slowDownTimer = 0;
    private float slowDownDuration;
    private float slowDownMultiplier = 0.75f;

    private bool isSlowed = false;

    private const float HORIZONTAL_BORDER = 1.3f;
    private const float VERTICAL_BORDER = 4.0f;

    private void Awake() => rb = GetComponent<Rigidbody2D>();

    private void FixedUpdate()
    {
        MovePlayer();

        if (isSlowed)
            MoveSlowed();
    }

    private void MovePlayer()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        float newXPosition = rb.position.x + horizontalInput * horizontalSpeed * Time.fixedDeltaTime;
        float newYPosition = rb.position.y + verticalInput * verticalSpeed * Time.fixedDeltaTime;

        newXPosition = Mathf.Clamp(newXPosition, -HORIZONTAL_BORDER, HORIZONTAL_BORDER);
        newYPosition = Mathf.Clamp(newYPosition, -VERTICAL_BORDER, VERTICAL_BORDER);

        rb.MovePosition(new Vector2(newXPosition, newYPosition));
    }

    private void MoveSlowed()
    {
        slowDownTimer += Time.deltaTime;

        if (slowDownTimer >= slowDownDuration)
        {
            slowDownTimer = 0;

            horizontalSpeed /= slowDownMultiplier;
            verticalSpeed /= slowDownMultiplier;

            isSlowed = false;
        }
    }

    public void StopMovement()
    {
        horizontalSpeed = 0;
        verticalSpeed = 0;
    }

    public void SlowMovement(float effectDuration)
    {
        if (isSlowed) return;

        isSlowed = true;

        slowDownDuration = effectDuration;

        horizontalSpeed *= slowDownMultiplier;
        verticalSpeed *= slowDownMultiplier;
    }
}
