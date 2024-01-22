using System.Collections;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using TMPro;
using System.Threading.Tasks;
using UnityEditor.VersionControl;
using System;

public class AuthManager : MonoBehaviour
{
    //Firebase variables
    [Header("Firebase")]
    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public FirebaseUser User;

    //Login variables
    [Header("Login")]
    public TMP_InputField emailLoginField;
    public TMP_InputField passwordLoginField;
    public TMP_Text warningLoginText;
    public TMP_Text confirmLoginText;

    //Register variables
    [Header("Register")]

    public TMP_InputField emailRegisterField;
    public TMP_InputField passwordRegisterField;
    public TMP_InputField passwordRegisterVerifyField;
    public TMP_Text warningRegisterText;
    public TMP_Text confirmRegisterText;

    private void Start()
    {
        warningLoginText.text = "";
        confirmLoginText.text = "";
        warningRegisterText.text = "";
        confirmRegisterText.text = "";
    }

    void Awake()
    {
        //Check that all of the necessary dependencies for Firebase are present on the system
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                //If they are avalible Initialize Firebase
                InitializeFirebase();
            }
            else
            {
                Debug.LogError("Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });
    }

    private void InitializeFirebase()
    {
        Debug.Log("Setting up Firebase Auth");
        //Set the authentication instance object
        auth = FirebaseAuth.DefaultInstance;
    }

    //Function for the login button
    public void LoginButton()
    {
        //Call the login coroutine passing the email and password
        StartCoroutine(Login(emailLoginField.text, passwordLoginField.text));
    }
    //Function for the register button
    public void RegisterButton()
    {
        //Call the register coroutine passing the email, password, and username
        StartCoroutine(Register(emailRegisterField.text, passwordRegisterField.text, "Anonymous"));
    }

    private IEnumerator Login(string _email, string _password)
    {
        //Call the Firebase auth signin function passing the email and password
        Task<AuthResult> LoginTask = auth.SignInWithEmailAndPasswordAsync(_email, _password);
        //Wait until the task completes
        yield return new WaitUntil(predicate: () => LoginTask.IsCompleted);

        if (LoginTask.Exception != null)
        {
            //If there are errors handle them
            Debug.LogWarning(message: $"Failed to register task with {LoginTask.Exception}");
            FirebaseException firebaseEx = LoginTask.Exception.GetBaseException() as FirebaseException;
            AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

            string message = "Login Failed!";

            warningLoginText.text = message;

            warningLoginText.color = Color.red;
            warningLoginText.text = message;
            confirmLoginText.text = "";
        }
        else
        {
            //User is now logged in
            //Now get the result
            User = LoginTask.Result.User;
            Debug.LogFormat("User signed in successfully: {0} ({1})", User.DisplayName, User.Email);

            confirmLoginText.color = Color.green;
            warningLoginText.text = "";
            confirmLoginText.text = "Logged In!";
        }
    }



    private IEnumerator Register(string _email, string _password, string _username)
    {
        warningRegisterText.color = Color.red;
        confirmRegisterText.color = Color.green;

        if (passwordRegisterField.text != passwordRegisterVerifyField.text)
        {
            //If the password does not match show a warning
            warningRegisterText.text = "Sign Up Failed!";
        }
        else
        {
            //Call the Firebase auth signin function passing the email and password
            Task<AuthResult> RegisterTask = auth.CreateUserWithEmailAndPasswordAsync(_email, _password);
            //Wait until the task completes
            yield return new WaitUntil(predicate: () => RegisterTask.IsCompleted);

            if (RegisterTask.Exception != null)
            {
                //If there are errors handle them
                Debug.LogWarning(message: $"Failed to register task with {RegisterTask.Exception}");
                FirebaseException firebaseEx = RegisterTask.Exception.GetBaseException() as FirebaseException;
                AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

                string message = "Sign Up Failed!";
                switch (errorCode)
                {
                    case AuthError.MissingEmail:
                        message = "Sign Up Failed!";
                        break;
                    case AuthError.MissingPassword:
                        message = "Sign Up Failed!";
                        break;
                    case AuthError.WeakPassword:
                        message = "Sign Up Failed!";
                        break;
                    case AuthError.EmailAlreadyInUse:
                        message = "Sign Up Failed!";
                        break;
                }

                confirmRegisterText.text = "";
                warningRegisterText.text = message;
            }
            else
            {
                //User has now been created
                //Now get the result
                User = RegisterTask.Result.User;

                if (User != null)
                {
                    //Create a user profile and set the username
                    UserProfile profile = new UserProfile { DisplayName = _username };

                    //Call the Firebase auth update user profile function passing the profile with the username
                    System.Threading.Tasks.Task ProfileTask = User.UpdateUserProfileAsync(profile);
                    //Wait until the task completes
                    yield return new WaitUntil(predicate: () => ProfileTask.IsCompleted);

                    if (ProfileTask.Exception != null)
                    {
                        //If there are errors handle them
                        Debug.LogWarning(message: $"Failed to register task with {ProfileTask.Exception}");
                        FirebaseException firebaseEx = ProfileTask.Exception.GetBaseException() as FirebaseException;
                        AuthError errorCode = (AuthError)firebaseEx.ErrorCode;
                        warningRegisterText.text = "Username Set Failed!";
                    }
                    else
                    {
                        //Username is now set
                        //Now return to login screen
                        confirmRegisterText.text = "Sign Up Successful!";
                        warningRegisterText.text = "";

                        //wait 2 seconds 
                        // UIManager.instance.LoginScreen();

                        Invoke(nameof(GoLoginScreen), 2f);


                    }
                }
            }
        }
    }

    private void GoLoginScreen()
    {
        UIManager.instance.LoginScreen();
    }
}
