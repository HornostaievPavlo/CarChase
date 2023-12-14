using UnityEngine;

public class PlayerPickupsHandler : MonoBehaviour
{
    [HideInInspector] public PickupState currentPickup;

    [HideInInspector] public float pickUpTimer;
    [HideInInspector] public float pickUpEffectDuration = 15.0f;

    [SerializeField] private Sprite defaultPlayer;
    [SerializeField] private Sprite playerWithMagnet;
    [SerializeField] private Sprite playerWithShield;
    [SerializeField] private Sprite playerWithNitro;

    [SerializeField] private GameObject magnetGlow;
    [SerializeField] private GameObject shieldGlow;
    [SerializeField] private GameObject nitroGlow;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        EventsHandler.LevelFailed.AddListener(() => UpdatePickupVisual(PickupState.None));
    }

    private void Update()
    {
        if (currentPickup == PickupState.None) return;

        UpdatePickupTimer();
    }

    private void UpdatePickupTimer()
    {
        pickUpTimer -= Time.deltaTime;

        if (pickUpTimer < 0f)
        {
            pickUpTimer = pickUpEffectDuration;
            UpdatePickupVisual(PickupState.None);
        }
    }

    public void UpdatePickupVisual(PickupState newPickup)
    {
        pickUpTimer = pickUpEffectDuration;
        currentPickup = newPickup;

        switch (currentPickup)
        {
            case PickupState.None:
                spriteRenderer.sprite = defaultPlayer;
                magnetGlow.SetActive(false);
                shieldGlow.SetActive(false);
                nitroGlow.SetActive(false);
                break;

            case PickupState.Magnet:
                spriteRenderer.sprite = playerWithMagnet;
                magnetGlow.SetActive(true);

                shieldGlow.SetActive(false);
                nitroGlow.SetActive(false);

                break;

            case PickupState.Shield:
                spriteRenderer.sprite = playerWithShield;
                shieldGlow.SetActive(true);

                magnetGlow.SetActive(false);
                nitroGlow.SetActive(false);
                break;

            case PickupState.Nitro:
                spriteRenderer.sprite = playerWithNitro;
                nitroGlow.SetActive(true);

                magnetGlow.SetActive(false);
                shieldGlow.SetActive(false);
                break;
        }
    }
}
