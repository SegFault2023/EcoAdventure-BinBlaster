using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class levelmenuMulti : MonoBehaviour
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
        if(levelId == 1)
        {
            SceneManager.LoadScene("level1MP");
        }
        if (levelId == 2)
        {
            SceneManager.LoadScene("level2mp");
        }
        if (levelId == 3)
        {
            SceneManager.LoadScene("level3mp");
        }
        if (levelId == 4)
        {
            SceneManager.LoadScene("level4mp");
        }
       
    }
}
