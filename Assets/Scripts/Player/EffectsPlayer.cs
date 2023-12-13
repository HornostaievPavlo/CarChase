using System.Collections;
using UnityEngine;

public class EffectsPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject crushPrefab;

    [SerializeField]
    private GameObject crushPanel;

    private void Start()
    {
        EventsHandler.PlayerCrushed.AddListener(PlayCrushEffect);
    }

    private void PlayCrushEffect(Vector3 crushPosition)
    {
        Instantiate(crushPrefab, crushPosition, Quaternion.identity);

        StartCoroutine(ShowCrushPanel());
    }

    private IEnumerator ShowCrushPanel()
    {
        crushPanel.SetActive(true);

        yield return new WaitForSeconds(2f);

        crushPanel.SetActive(false);
    }
}
