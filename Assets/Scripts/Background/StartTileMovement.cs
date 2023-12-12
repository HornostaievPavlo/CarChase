using UnityEngine;

public class StartTileMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    private const float LOWER_BORDER = -10f;

    private void Update()
    {
        Vector3 verticalMovement = Vector3.down * movementSpeed * Time.deltaTime;

        transform.Translate(verticalMovement);

        if (transform.position.y < LOWER_BORDER)
            Destroy(gameObject);
    }
}
