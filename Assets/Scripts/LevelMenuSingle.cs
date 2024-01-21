using UnityEngine;
using UnityEngine.UI;

public class LevelMenuSingle : MonoBehaviour
{
    public Button[] buttons;
    public GameObject[] buttonMasks;

    private void Awake()
    {
        for (int i = 0; i < buttons.Length; i++)
            buttons[i].interactable = true;

        //buttonMasks[i].SetActive(false);

    }

    public void OpenLevel(int levelId)
    {
        string levelName = "Level" + levelId;
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
    }

    // Call this method when a level is successfully completed
    public void CompleteLevel(int levelId)
    {
        buttonMasks[levelId].SetActive(false);

        // Save the completion status to PlayerPrefs
        PlayerPrefs.SetInt("LevelCompleted" + levelId, 1);
        PlayerPrefs.Save();
    }
}
