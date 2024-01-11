using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text timeText;

    private float remainingTime;

    [SerializeField]
    private float startTimeInSeconds = 120f;



    // Start is called before the first frame update
    void Start()
    {
        remainingTime = startTimeInSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        if(remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }

        else if(remainingTime < 0)
        {
            remainingTime = 0;
            timeText.color = Color.red;
            SceneManager.LoadScene(2);

        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
