using UnityEngine;

public class CameraSizeFitter : MonoBehaviour
{
    private Camera _camera;

    public SpriteRenderer roadTile;

    private void Awake()
    {
        _camera = GetComponent<Camera>();

        float fitSize = roadTile.bounds.size.x * Screen.height / Screen.width * 0.5f;
        _camera.orthographicSize = fitSize;
    }
}
