using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PickUpBar : MonoBehaviour
{
    [SerializeField]
    private PlayerPickupsHandler pickupsHandler;

    [SerializeField]
    private GameObject barParent;

    [SerializeField] private Sprite magnetFill;
    [SerializeField] private Sprite shieldFill;
    [SerializeField] private Sprite nitroFill;

    private Image fillImage;
    private TMP_Text barText;

    private const string MAGNET_NAME = "Magnet";
    private const string SHIELD_NAME = "Shield";
    private const string NITRO_NAME = "Nitro";

    private void Awake()
    {
        fillImage = barParent.GetComponentsInChildren<Image>()[1];
        barText = barParent.GetComponentInChildren<TMP_Text>();
    }

    private void Update() => ShowCurrentPickUpBar();

    private void ShowCurrentPickUpBar()
    {
        if (pickupsHandler.currentPickup == PickupState.None)
        {
            barParent.SetActive(false);
            return;
        }

        switch (pickupsHandler.currentPickup)
        {
            case PickupState.Magnet:
                fillImage.sprite = magnetFill;
                barText.text = MAGNET_NAME;
                break;

            case PickupState.Shield:
                fillImage.sprite = shieldFill;
                barText.text = SHIELD_NAME;
                break;

            case PickupState.Nitro:
                fillImage.sprite = nitroFill;
                barText.text = NITRO_NAME;
                break;
        }

        barParent.SetActive(true);

        fillImage.fillAmount = Mathf.Clamp01(pickupsHandler.pickUpTimer / pickupsHandler.pickUpEffectDuration);
    }
}
