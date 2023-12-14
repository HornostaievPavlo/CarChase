using UnityEngine;

public class CameraSizeFitter : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer roadTile;

    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();

        float sizeToFitRoadWidth = roadTile.bounds.size.x * Screen.height / Screen.width * 0.5f;
        _camera.orthographicSize = sizeToFitRoadWidth;
    }
}
