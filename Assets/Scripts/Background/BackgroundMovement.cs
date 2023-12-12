using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    private Vector3 startPos;

    private const float RESET_POSITION = 0f;

    private void Start() => startPos = transform.position;

    private void Update()
    {
        Vector3 verticalMovement = Vector3.down * movementSpeed * Time.deltaTime;

        transform.Translate(verticalMovement);

        if (transform.position.y < RESET_POSITION)
            transform.position = startPos;
    }
}
