using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialization : MonoBehaviour
{
    void Start()
    {
        //Player.instance = GetPlayerByID();
    }

    private static Player GetPlayerByID()
    {
        return new Player();
    }
}
