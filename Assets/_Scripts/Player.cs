using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    private int tickets;
    private int level;

    public Action<int> OnTicketChange;
    public Action<int> OnLevelChange;

    public DateTime LastBonusTime { get; private set; }

    private void Awake()
    {
        if (instance != null)
            throw new Exception("It is unacceptable to have more than 1 player!");

        instance = this;
    }

    [ContextMenu("ResetBonus")]
    private void ResetBonus()
    {
        LastBonusTime = DateTime.Now.AddDays(-1);
    }

    public void AddBonusReward(int reward)
    {
        tickets += reward;
        LastBonusTime = DateTime.Now;
        OnTicketChange?.Invoke(tickets);
    }
    public int GetTickets()
    {
        return tickets;
    }
    public void NewLevel()
    {
        level++;
        OnLevelChange?.Invoke(level);
    }
}
