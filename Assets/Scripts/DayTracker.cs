using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayTracker : MonoBehaviour
{
    public PlayerController Player;
    public bool endGame;
    public int dayTracker;
    void Start()
    {
        dayTracker = 1;
        GetComponent<TextMeshProUGUI>().text = "Day: " + dayTracker.ToString() + " / 3";
        endGame = false;
    }

    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = "Day: " + dayTracker.ToString() + " / 3";
        if (dayTracker == 4)
        {
            if (endGame == false)
            {
                Player.EndGame();
                endGame = true;

            }
        }
    }
    
}
