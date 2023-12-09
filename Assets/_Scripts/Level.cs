using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image), typeof(Button))]
public class Level : MonoBehaviour
{
    public int ID;
    private Image image;
    private Button button;
    private TextMeshProUGUI text;

    private bool onSubscription;


    private void Start()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
        text = GetComponentInChildren<TextMeshProUGUI>();
        ID = int.Parse(text.text);

        Player.instance.OnLevelChange += CheckAccess;
        onSubscription = true;

        CheckAccess(Player.instance.GetLevel());
    }

    private void CheckAccess(int playerLevel)
    {
        if (playerLevel >= ID)
            OpenLevel();
        else
            CloseLevel();
    }

    private void CloseLevel()
    {
        text.enabled = false;
        button.interactable = false;
        image.sprite = Resources.Load<Sprite>("Textures/levels/LockLevel");
    }

    private void OpenLevel()
    {
        text.enabled = true;
        button.interactable = true;
        image.sprite = Resources.Load<Sprite>("Textures/levels/OpenLevel");
    }

    public void LevelStart()
    {
        if(ID == Player.instance.GetLevel())
        {
            Player.instance.NewLevel();
            Player.instance.OnLevelChange -= CheckAccess;
            onSubscription = false;
        }
    }

    private void OnDestroy()
    {
        if(onSubscription)
            Player.instance.OnLevelChange -= CheckAccess;
    }
}
