using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    private int countdownValue = 3;

    [SerializeField]
    private TMP_Text timeText;

    [SerializeField]
    private Image translucentMask; // Reference to the translucent mask image

    private bool countdownFinished = false;

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
            RemoveGo();
            CancelInvoke("CountdownAndGo");
        }
    }

    void RemoveGo()
    {
        translucentMask.enabled = false; // Hide the translucent mask
        countdownFinished = true;
        timeText.enabled = false;
        // You may add any other actions needed to start the game after "Go!" is displayed.
    }

    // Add a public method to check if the countdown has finished
    public bool IsCountdownFinished()
    {
        return countdownFinished;
    }
}