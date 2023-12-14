using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Image fillImage;

    private void Awake()
    {
        EventsHandler.PlayerHealthUpdated.AddListener(HandleHealthChange);
    }

    private void HandleHealthChange(float percent)
    {
        StartCoroutine(ChangeToPercent(percent));
    }

    private IEnumerator ChangeToPercent(float percent)
    {
        float elapsedTime = 0f;
        float updateSpeed = 1.5f;
        float preChangePercent = fillImage.fillAmount;

        while (elapsedTime < updateSpeed)
        {
            elapsedTime += Time.deltaTime;

            fillImage.fillAmount = Mathf.Lerp(preChangePercent, percent, elapsedTime / updateSpeed);

            yield return null;
        }

        fillImage.fillAmount = percent;
    }
}
