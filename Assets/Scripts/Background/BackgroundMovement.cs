using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    private float movementSpeed = 3f;

    private Vector3 startPos;

    private const float RESET_POSITION = 0f;

    private void Start()
    {
        startPos = transform.position;

        EventsHandler.LevelFailed.AddListener(StopMovement);
    }

    private void Update() => MoveBackground();

    private void MoveBackground()
    {
        Vector3 movementDirection = Vector3.down * movementSpeed * Time.deltaTime;

        transform.Translate(movementDirection);

        if (transform.position.y < RESET_POSITION)
            transform.position = startPos;
    }

    private void StopMovement() => movementSpeed = 0f;
}
