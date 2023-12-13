using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float horizontalSpeed;

    [SerializeField]
    private float verticalSpeed;

    private Rigidbody2D rb;

    private float currentHorSpeed;
    private float currentVertSpeed;

    private bool isSpeedModified = false;

    private const float HORIZONTAL_BORDER = 1.3f;
    private const float VERTICAL_BORDER = 4.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        currentHorSpeed = horizontalSpeed;
        currentVertSpeed = verticalSpeed;
    }

    private void FixedUpdate() => MovePlayer();

    private void MovePlayer()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        float newXPosition = rb.position.x + horizontalInput * currentHorSpeed * Time.fixedDeltaTime;
        float newYPosition = rb.position.y + verticalInput * currentVertSpeed * Time.fixedDeltaTime;

        newXPosition = Mathf.Clamp(newXPosition, -HORIZONTAL_BORDER, HORIZONTAL_BORDER);
        newYPosition = Mathf.Clamp(newYPosition, -VERTICAL_BORDER, VERTICAL_BORDER);

        rb.MovePosition(new Vector2(newXPosition, newYPosition));
    }

    public IEnumerator ChangeMovementSpeed(float speedMultiplier, float effectDuration)
    {
        if (isSpeedModified)
            yield break;

        isSpeedModified = true;

        currentHorSpeed *= speedMultiplier;
        currentVertSpeed *= speedMultiplier;

        yield return new WaitForSecondsRealtime(effectDuration);

        currentHorSpeed = horizontalSpeed;
        currentVertSpeed = verticalSpeed;

        isSpeedModified = false;
    }

    public void ResetSpeed()
    {
        currentHorSpeed = horizontalSpeed;
        currentVertSpeed = verticalSpeed;

        isSpeedModified = false;
    }
}
