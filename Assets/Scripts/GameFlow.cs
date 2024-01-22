using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlow : MonoBehaviour
{


    [SerializeField]
    public GameObject squareObject;

    private bool isStopped = false;
    // Start is called before the first frame update
    void Start()
    {
        squareObject = transform.Find("Canvas1").gameObject;
        isStopped = false;
    }

    public bool getIsStopped() { return isStopped; }


    void Update()
    {
        // Check if the 'Escape' key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle the game's time scale between 0 (paused) and 1 (normal speed)
            if (Time.timeScale == 0f)
            {
                // If the game is already paused, resume it
                ResumeGame();
            }
            else
            {
                // If the game is not paused, pause it
               PauseGame();
            }
        }
    }

    private void PauseGame()
    {
                squareObject.SetActive(true);
               
                isStopped = true;
                Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
                squareObject.SetActive(false);
              
                Time.timeScale = 1f;
                isStopped = false;
    }

    public void ResumeButton()
    {
        ResumeGame();
    }

    public void GoToMainMenuButton()
    {
        string sceneName = "MainMenu";


        // Load the MainMenu scene
        SceneManager.LoadScene(sceneName);
    }


}
