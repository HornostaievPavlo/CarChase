using UnityEngine;

public class DownwardMovement : MonoBehaviour
{
    private float movementSpeed = 3f;

    private const float LOWER_BORDER = -10f;

    private void Start() => EventsHandler.LevelFailed.AddListener(StopMovement);

    private void Update() => ApplyMovement();

    private void ApplyMovement()
    {
        Vector3 movementDirection = Vector3.down * movementSpeed * Time.deltaTime;

        transform.Translate(movementDirection);

        if (transform.position.y < LOWER_BORDER)
            Destroy(gameObject);
    }

    private void StopMovement() => movementSpeed = 0f;
}
