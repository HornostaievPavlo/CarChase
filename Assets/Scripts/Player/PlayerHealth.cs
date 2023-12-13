using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;

    private float currentHealth;

    private const float HEALTH_POINT_VALUE = 25f;

    private void Start()
    {
        currentHealth = maxHealth;

        EventsHandler.HealthPointCollected.AddListener(HealPlayer);
    }

    private void HealPlayer()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += HEALTH_POINT_VALUE;
            EventsHandler.OnPlayerHealthUpdated(currentHealth / maxHealth);
        }
    }

    public void DamagePlayer(float damageAmount)
    {
        currentHealth -= damageAmount;

        float currentHealthPercent = currentHealth / maxHealth;

        EventsHandler.OnPlayerHealthUpdated(currentHealthPercent);

        if (currentHealth <= 0)
        {
            EventsHandler.OnLevelFailed();
        }
    }
}
