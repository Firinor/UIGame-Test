using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;
    [SerializeField]
    private GameObject levels;
    [SerializeField]
    private GameObject shop;
    [SerializeField]
    private GameObject settings;
    [SerializeField]
    private GameObject dailyBonus;
    [SerializeField]
    private GameObject superBonus;

    public void ToMenu()
    {
        levels.SetActive(false);
        shop.SetActive(false);
        settings.SetActive(false);
        dailyBonus.SetActive(false);
        superBonus.SetActive(false);

        menu.SetActive(true);
    }

    public void ToLevels()
    {
        menu.SetActive(false);

        levels.SetActive(true);
    }

    public void ToShop()
    {
        menu.SetActive(false);

        shop.SetActive(true);
    }

    public void ToBonus()
    {
        dailyBonus.SetActive(true);
    }

    public void ToSettings()
    {
        settings.SetActive(true);
    }
}
