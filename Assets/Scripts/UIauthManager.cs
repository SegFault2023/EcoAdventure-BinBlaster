
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIauthManager : MonoBehaviour
{
   public static UIauthManager instance;

    //Screen object variables
    public GameObject loginUI;
    public GameObject registerUI;

    public TMP_Text firstText; // confirm
    public TMP_Text secondText; // warning log
    public TMP_Text thirdText; // confirm sign
    public TMP_Text fourthText;


    public void Start()
    {

       
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    //Functions to change the login screen UI
    public void LoginScreen() //Back button
    {
        cleanRegisterScreen();
        cleanLoginScreen();
        loginUI.SetActive(true);
        registerUI.SetActive(false);
    }
    public void RegisterScreen() // Regester button
    {
        cleanRegisterScreen();
        cleanLoginScreen();
        loginUI.SetActive(false);
        registerUI.SetActive(true);
    }

    private void cleanLoginScreen()
    {

        // Modify the content of the Text objects
        firstText.text = "";
        secondText.text = "";
    }

    private void cleanRegisterScreen()
    {

        // Modify the content of the Text objects
        thirdText.text = "";
        fourthText.text = "";
    }

    public void GoBackMainMenu()
    {
        string sceneName = "MainMenu";

        cleanRegisterScreen();
        cleanLoginScreen();

        // Load the MainMenu scene
        SceneManager.LoadScene(sceneName);
    }

}
