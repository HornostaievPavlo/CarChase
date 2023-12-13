using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Image fillImage;

    [SerializeField]
    private float updateSpeed;

    [SerializeField]
    private PlayerHealth playerHealth;

    private void Awake()
    {
        playerHealth.PlayerDamaged.AddListener(HandleHealthChange);
    }

    private void HandleHealthChange(float percent)
    {
        StartCoroutine(ChangeToPercent(percent));
    }

    private IEnumerator ChangeToPercent(float percent)
    {
        float preChangePercent = fillImage.fillAmount;

        float elapsedTime = 0f;

        while (elapsedTime < updateSpeed)
        {
            elapsedTime += Time.deltaTime;

            fillImage.fillAmount = Mathf.Lerp(preChangePercent, percent, elapsedTime / updateSpeed);

            yield return null;
        }

        fillImage.fillAmount = percent;
    }
}
