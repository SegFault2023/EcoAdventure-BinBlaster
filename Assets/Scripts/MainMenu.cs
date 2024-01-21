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
        SceneManager.LoadSceneAsync(8);
    }
    public void Level2()
    {
        SceneManager.LoadSceneAsync(6);
    }
    public void Level3()
    {
        SceneManager.LoadSceneAsync(9);
    }
    public void Level4()
    {
        SceneManager.LoadSceneAsync(10);
    }

    public void LevelScene()
    {
        SceneManager.LoadSceneAsync(11);

    }

    public void MainMen()
    {
        SceneManager.LoadSceneAsync(13);

    }

    public void SimOrMul()
    {
        SceneManager.LoadSceneAsync(14);

    }
    public void SignUp()
    {
        SceneManager.LoadSceneAsync(15);

    }

    public void mpLobi()
    {
        SceneManager.LoadSceneAsync(0);

    }

}
