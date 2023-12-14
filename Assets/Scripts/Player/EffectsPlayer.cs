using System.Collections;
using UnityEngine;

public class EffectsPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject crushEffect;

    [SerializeField]
    private GameObject crushPanel;

    private void Start()
    {
        EventsHandler.PlayerCrushed.AddListener(PlayCrushEffect);
    }

    private void PlayCrushEffect(Vector3 crushPosition)
    {
        var newCrush = Instantiate(crushEffect, crushPosition, Quaternion.identity);

        StartCoroutine(ShowCrushPanel(newCrush));
    }

    private IEnumerator ShowCrushPanel(GameObject currentCrushPrefab)
    {
        crushPanel.SetActive(true);

        yield return new WaitForSeconds(0.25f);
        currentCrushPrefab.SetActive(false);

        yield return new WaitForSeconds(0.5f);
        crushPanel.SetActive(false);
    }
}
