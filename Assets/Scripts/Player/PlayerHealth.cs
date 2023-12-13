using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;

    private float currentHealth;

    public UnityEvent<float> PlayerDamaged = new UnityEvent<float>();

    private void Start()
    {
        currentHealth = maxHealth;

        PlayerDamaged.AddListener(ModifyHealth);
    }

    private void ModifyHealth(float amount)
    {
        currentHealth -= amount;

        float currentHealthPercent = currentHealth / maxHealth;

        PlayerDamaged.Invoke(currentHealthPercent);

        if (currentHealth == 0)
        {
            Destroy(gameObject);
        }
    }
}
