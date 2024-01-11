using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public void SignUp()
    {
        SceneManager.LoadSceneAsync(6);
    }

    public void LogIn()
    {
        SceneManager.LoadSceneAsync(5);
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(7);
    }
}