using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;



public class PauseAndExit : MonoBehaviour
{
    private bool isGamePaused = false;
    [SerializeField]
    public GameObject squareObject;
    private bool isStopped = false;


    void Start()
    {
        squareObject = transform.Find("Canvas1").gameObject;

    }

    public bool getIsStopped() { return isStopped; }


    private void Update()
    {
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

    private void ResumeGame()
    {
        squareObject.SetActive(false);

        Time.timeScale = 1f;
        isStopped = false;
    }

    private void DisconnectAndExit()
    {


        // Load the MainMenu scene

        PhotonNetwork.Disconnect(); // Disconnect from Photon
        StartCoroutine(WaitForDisconnectAndExit());

    }

    private System.Collections.IEnumerator WaitForDisconnectAndExit()
    {
        string sceneName = "PlayTypeSelect";
                // Load your main menu scene or another desired scene

        // Wait for the Photon disconnection to complete
        yield return new WaitForSeconds(0.001f);
        SceneManager.LoadScene(sceneName);
        // Load your main menu scene or another desired scene
    }


    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Ensure that the game is not paused when a new scene is loaded
        ResumeGame();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void ResumeButton()
    {
        ResumeGame();
    }

    public void GoToMainMenuButton()
    {
        DisconnectAndExit();
    }
}
