using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LevelMenuSingle : MonoBehaviour
{
    public Button button;
    public GameObject buttonMask;
    [SerializeField] private bool unlocked = false;
    [SerializeField] private int levelNo;

    private void Update()
    {
        UpdateLevelMask();
        UpdateLevelStatus();
    }

    public void UpdateLevelStatus()
    {
        int levelNumber = PlayerPrefs.GetInt("CurrentLevelNumber", 1);
        if (PlayerPrefs.GetInt("LevelStatus", 0) == 1 && levelNumber == levelNo)
            unlocked = true;

        Debug.Log("ayoo level number: " + levelNo + " unlocked? " + unlocked);
    }
    private void UpdateLevelMask()
    {
        if (!unlocked)
        {
            buttonMask.gameObject.SetActive(true);
            Debug.Log("If not unlocked");
        }

        if (unlocked)
        {
            buttonMask.gameObject.SetActive(false);
            Debug.Log("If  unlocked");
        }

    }
    public void PressSelection(string LevelName)
    {
        SceneManager.LoadScene(LevelName);
    }
}
