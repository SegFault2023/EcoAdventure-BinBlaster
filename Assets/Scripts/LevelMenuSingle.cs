using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenuSingle : MonoBehaviour
{
    public Button[] buttons;
    public GameObject[] buttonMasks;

    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;

            // Set initial color to black and white
            //buttons[i].image.color = Color.gray;

            // Activate or deactivate the mask based on level lock
            buttonMasks[i].SetActive(!buttons[i].interactable);
        }

        if (unlockedLevel > 0 && unlockedLevel <= buttons.Length)
        {
            for (int i = 0; i < unlockedLevel; i++)
            {
                buttons[i].interactable = true;

                // Change color to white for unlocked buttons
                //buttons[i].image.color = Color.white;

                // Activate or deactivate the mask based on level lock
                buttonMasks[i].SetActive(!buttons[i].interactable);
            }
        }
    }

    public void OpenLevel(int levelId)
    {
        string levelName = "Level" + levelId;
        SceneManager.LoadScene(levelName);
    }
}
