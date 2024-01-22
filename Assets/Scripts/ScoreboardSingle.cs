using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreboardSingle : MonoBehaviour
{
    [SerializeField]
    private TMP_Text finalScoreText;

    [SerializeField]
    private TMP_Text gameResultText;

    [SerializeField]
    private TMP_Text levelInfoText;

    [SerializeField]
    private int scoreLimitForSuccess = 2; // Set your desired score limit for success here

    [SerializeField]
    private Button backButton;

    public int levelStatus;
    // Start is called before the first frame update
    void Start()
    {
        DisplayFinalScore();
        DisplayGameResult();
        DisplayLevelInfo();

        // Attach the method to the Back button click event
        if (backButton != null)
        {
            backButton.onClick.AddListener(GoBackToLevelMap);
        }
    }

    void DisplayFinalScore()
    {
        int finalScore = ScoreManager.getScore();
        finalScoreText.text = "Score: \n" + finalScore.ToString();
    }

    void DisplayGameResult()
    {
        int finalScore = ScoreManager.getScore();
        Scene currentScene = SceneManager.GetActiveScene();

        if (finalScore >= scoreLimitForSuccess)
        {
            gameResultText.text = "Congratulations! Level Completed Successfully!";
            gameResultText.color = Color.green; // Set color to green
            UnlockNewLevel();
        }

        else
        {
            gameResultText.text = "GAME OVER.\n Try again!";
            gameResultText.color = Color.red; // Set color to red
        }
    }

    void DisplayLevelInfo()
    {
        int levelNumber = PlayerPrefs.GetInt("CurrentLevelNumber", 1);
        levelInfoText.text = "Level " + levelNumber.ToString();
    }

    // Method to handle the Back button click event
    void GoBackToLevelMap()
    {
        SceneManager.LoadScene("LevelMapSingle");
    }

    void UnlockNewLevel()
    {
        int levelNumber = PlayerPrefs.GetInt("CurrentLevelNumber", 1);
        if (levelNumber >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", levelNumber + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }
}
