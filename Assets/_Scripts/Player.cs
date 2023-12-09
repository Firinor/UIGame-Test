using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    private int tickets;
    public int Tickets 
    { 
        get { return tickets; }
        set 
        {
            tickets = value;
            OnTicketChange?.Invoke(value);
        } 
    }
    private int level = 1;

    public List<string> Goods = new(); //locations, skins (by ID)

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
    public void AddTickets(int reward)
    {
        tickets += reward;
        OnTicketChange?.Invoke(tickets);
    }
    public int GetTickets()
    {
        return tickets;
    }
    public int GetLevel()
    {
        return level;
    }
    public void NewLevel()
    {
        level++;
        OnLevelChange?.Invoke(level);
    }
}
