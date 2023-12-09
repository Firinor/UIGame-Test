using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Offer : MonoBehaviour
{
    [SerializeField]
    private string ID;

    [Space]
    [SerializeField]
    private GameObject iconImage;
    [SerializeField]
    private GameObject iconPlaceholder;
    [SerializeField]
    private GameObject iconLock;
    private TextMeshProUGUI iconLockText;
    private Button button;

    [Space]
    [SerializeField]
    private GameObject purchasedIcon;
    [SerializeField]
    private GameObject priceIcon;
    [SerializeField]
    private TextMeshProUGUI priceText;

    [Space]
    [SerializeField]
    private int priceInTickets;

    [SerializeField]
    private int levelRestriction;
    private bool onSubscription;

    private void Awake()
    {
        button = GetComponent<Button>();
        iconLockText = iconLock.GetComponentInChildren<TextMeshProUGUI>();
        iconLockText.text = "LV. " + levelRestriction;
        priceText.text = priceInTickets.ToString();
    }

    private void Start()
    {
        Player.instance.OnLevelChange += CheckRestriction;
        onSubscription = true;
        CheckRestriction(Player.instance.GetLevel());
    }

    private void CheckRestriction(int playerLevel)
    {
        if (playerLevel < levelRestriction)
            LockOffer();
        else
            OpenOffer();
    }

    private void OpenOffer()
    {
        button.interactable = true;

        iconLock.SetActive(false);

        if (iconImage.GetComponent<Image>().sprite == null)
            iconPlaceholder.SetActive(true);
        else
            iconImage.SetActive(true);

        CheckPurchased();

        onSubscription = false;
        Player.instance.OnLevelChange -= CheckRestriction;
    }

    private void CheckPurchased()
    {
        if (Player.instance.Goods.Contains(ID))
        {
            HidePrice();
        }
        else
        {
            ShowPrice();
        }
    }

    private void HidePrice()
    {
        button.interactable = false;
        purchasedIcon.SetActive(true);
        priceIcon.SetActive(false);
        priceText.gameObject.SetActive(false);
    }

    private void ShowPrice()
    {
        purchasedIcon.SetActive(false);
        priceIcon.SetActive(true);
        priceText.gameObject.SetActive(true);
    }

    private void LockOffer()
    {
        button.interactable = false;

        iconImage.SetActive(false);
        iconPlaceholder.SetActive(false);

        iconLock.SetActive(true);

        ShowPrice();
    }

    public void TryBuy()
    {
        if (Player.instance.Tickets >= priceInTickets)
        {
            Player.instance.Tickets -= priceInTickets;
            Player.instance.Goods.Add(ID);
            HidePrice();
        }
        else
            Debug.LogWarning("Not enough tickets!");
    }

    private void OnDestroy()
    {
        if(onSubscription)
            Player.instance.OnLevelChange -= CheckRestriction;
    }
}
