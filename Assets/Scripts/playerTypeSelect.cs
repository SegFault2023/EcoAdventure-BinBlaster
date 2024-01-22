using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerTypeSelect : MonoBehaviour
{
    public void SinglePlayer()
    {
        SceneManager.LoadSceneAsync("LevelMapSingle");
    }

    public void MultiPlayer()
    {
        SceneManager.LoadSceneAsync("mplobi");
    }


}
