using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayTypeSelect : MonoBehaviour
{
    public void SinglePlayer()
    {
        SceneManager.LoadSceneAsync("LevelMap");
    }

    public void MultiPlayer()
    {
        SceneManager.LoadSceneAsync("mplobi");
    }
}
