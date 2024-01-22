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
        for (int i = 0; i < buttons.Length; i++)
            buttons[i].interactable = true;

        //buttonMasks[i].SetActive(false);

    }

    // Call this method when a level is successfully completed
    public void CompleteLevel(int levelId)
    {
        buttonMasks[levelId].SetActive(false);

        // Save the completion status to PlayerPrefs
        PlayerPrefs.SetInt("LevelCompleted" + levelId, 1);
        PlayerPrefs.Save();
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
