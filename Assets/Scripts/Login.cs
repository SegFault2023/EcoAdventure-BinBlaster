using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public void SignUp()
    {
        SceneManager.LoadSceneAsync(4);
    }

    public void LogIn()
    {
        SceneManager.LoadSceneAsync(3);
    }
}