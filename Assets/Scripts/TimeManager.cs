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
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime <= 0)
        {
            remainingTime = 0;
            timeText.color = Color.red;

            // Save the final score and scene name to PlayerPrefs before loading the Scoreboard scene
            PlayerPrefs.SetInt("FinalScore", ScoreManager.getScore());
            PlayerPrefs.SetString("SceneName", SceneManager.GetActiveScene().name);

            int currentLevelId = GetCurrentLevelId(); // Get the current level ID
            CompleteLevel(currentLevelId); // Call the CompleteLevel method with the correct level ID

            SceneManager.LoadScene("ScoreboardSingle");
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    int GetCurrentLevelId()
    {
        // Extract the level ID from the current scene name (assuming the scene name format is "LevelX")
        string sceneName = SceneManager.GetActiveScene().name;
        int levelId;
        if (int.TryParse(sceneName.Substring("Level".Length), out levelId))
        {
            return levelId;
        }
        return -1; // Return -1 if the level ID cannot be determined
    }

    // Call this method when a level is successfully completed
    void CompleteLevel(int levelId)
    {
        // Save the completion status to PlayerPrefs
        PlayerPrefs.SetInt("LevelCompleted" + levelId, 1);
        PlayerPrefs.Save();
    }
}
