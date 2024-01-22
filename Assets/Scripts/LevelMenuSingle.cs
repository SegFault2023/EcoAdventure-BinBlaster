using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LevelMenuSingle : MonoBehaviour
{
    public Button[] buttons;
    public GameObject[] masks;

    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
            masks[i].gameObject.SetActive(true);
        }

        for (int i = 0; i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;
            masks[i].gameObject.SetActive(false);
        }
    }
    public void OpenLevel(int levelId)
    {
        string levelName = "Level" + levelId;
        SceneManager.LoadScene(levelName);
    }
}
