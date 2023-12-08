using System;
using System.Collections.ObjectModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bonus : MonoBehaviour
{
    [SerializeField]
    private GameObject superBonus;
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private TextMeshProUGUI sliderText;
    [SerializeField]
    private TextMeshProUGUI dayText;
    [SerializeField]
    private TextMeshProUGUI ticketsCountText;

    private int rewardIndex;
    private readonly ReadOnlyCollection<int> rewards = new(new int[]{ 5, 5, 10, 10, 15, 15, 5 });

    private void Awake()
    {
        rewardIndex = GetRewardIndex();
    }
    private void OnEnable()
    {
        if (CheckTime())
            Player.instance.AddBonusReward(GetReward());
    }

    private int GetReward()
    {
        int reward = rewards[rewardIndex];

        rewardIndex++;

        ShowBonus(reward, day: rewardIndex);
        RefreshSlider(day: rewardIndex);

        if (rewardIndex > 6)
            rewardIndex = 0;

        return reward;
    }

    private void RefreshSlider(int day)
    {
        slider.value = day;
        sliderText.text = day + "/7";
    }

    private void ShowBonus(int reward, int day)
    {
        superBonus.SetActive(true);
        dayText.text = "DAY " + day;
        ticketsCountText.text = "X" + reward;
    }

    private int GetRewardIndex()
    {
        return 0;
    }
    private bool CheckTime()
    {
        DateTime day = Player.instance.LastBonusTime.Date;

        return day < DateTime.Now.Date;
    }
}
