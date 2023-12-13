using UnityEngine;

public class EffectsPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject crushPrefab;

    private void Start()
    {
        EventsHandler.PlayerCrushed.AddListener(PlayCrushEffect);
    }

    private void PlayCrushEffect(Vector3 crushPosition)
    {
        Instantiate(crushPrefab, crushPosition, Quaternion.identity);
    }
}
