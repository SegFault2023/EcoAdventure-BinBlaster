using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("PlayTypeSelect");
    }

    public void LoginSignup()
    {
        SceneManager.LoadSceneAsync("Login");
    }

    public void SelectPlayType()
    {
        SceneManager.LoadSceneAsync("PlayTypeSelect");
    }

    public void HowToPlay()
    {
        SceneManager.LoadSceneAsync("HowToPlay");
    }
}
