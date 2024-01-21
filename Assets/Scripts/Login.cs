using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public void SignUp()
    {
        SceneManager.LoadSceneAsync("Signup");
    }

    public void LogIn()
    {
        SceneManager.LoadSceneAsync("Login");
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void Level1()
    {
        SceneManager.LoadSceneAsync("Level1");
    }
}