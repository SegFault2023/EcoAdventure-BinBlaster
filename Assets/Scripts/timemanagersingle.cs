using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timemanagersingle : MonoBehaviour
{
    [SerializeField]
    private TMP_Text timeText;

    private float remainingTime;

    [SerializeField]
    private float startTimeInSeconds = 120f;

    [SerializeField]
    private CountDown countdown;

    [SerializeField]
    private int currentLevelNumber = 1; // Set the level number for each scene

    // Start is called before the first frame update
    void Start()
    {
        remainingTime = startTimeInSeconds;
        PlayerPrefs.SetInt("CurrentLevelNumber", currentLevelNumber);
    }

    // Update is called once per frame
    void Update()
    {
        if (!countdown.IsCountdownFinished())
        {
            // Countdown actions if needed
        }
        else
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
            }
            else if (remainingTime <= 0)
            {
                remainingTime = 0;
                timeText.color = Color.red;
                // Load the Scoreboard scene
                SceneManager.LoadScene("ScoreboardSingle");
            }

            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
