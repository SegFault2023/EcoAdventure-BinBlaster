
using System;
using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    private int countdownValue = 3;

    [SerializeField]
    private TMP_Text timeText;


    void Start()
    {
        InvokeRepeating("CountdownAndGo", 0f, 1f);
    }

    void CountdownAndGo()
    {
        if (countdownValue > 0)
        {
            timeText.text = countdownValue.ToString();
            countdownValue--;
        }
        else if (countdownValue == 0)
        {       
            String str = "Go!";
            timeText.text = str;
            countdownValue--;
        }

        else
        {
            InvokeRepeating("RemoveGo", 0f, 1f);
            CancelInvoke("CountdownAndGo");
        }
    }

    void RemoveGo()
    {
        timeText.enabled = false;
    }
}

