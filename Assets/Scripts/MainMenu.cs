using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void LoginSignup()
    {
        SceneManager.LoadSceneAsync("Login");
    }

    public void SelectPlayType()
    {
        SceneManager.LoadSceneAsync("PlayTypeSelect");

    }

    public void Level1()
    {
        SceneManager.LoadSceneAsync("Level1");
    }
    public void Level2()
    {
        SceneManager.LoadSceneAsync("Level2");
    }
    public void Level3()
    {
        SceneManager.LoadSceneAsync("Level3");
    }
    public void Level4()
    {
        SceneManager.LoadSceneAsync("Level4");
    }

    public void LevelScene()
    {
        SceneManager.LoadSceneAsync("LevelMapSingle");

    }

    public void MainMen()
    {
        SceneManager.LoadSceneAsync("MainMenu");

    }

    public void SimOrMul()
    {
        SceneManager.LoadSceneAsync("PlayTypeSelect");

    }
    public void SignUp()
    {
        SceneManager.LoadSceneAsync("Signup");

    }

    public void mpLobi()
    {
        SceneManager.LoadSceneAsync("mblobi");

    }

}
