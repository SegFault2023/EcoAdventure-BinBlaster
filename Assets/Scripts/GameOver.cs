using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{

    [SerializeField]
    private TMP_Text scoreDisplayText;

    [SerializeField]
    private TMP_Text highScoreDisplayText;

    

    // Start is called before the first frame update
    void Start()
    {
        scoreDisplay();
        highScoreDisplay();
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    private void scoreDisplay()
    {
        scoreDisplayText.text = "Your score : " + ScoreManager.getScore();
    }

    private void highScoreDisplay()
    {
        highScoreDisplayText.text = "High Score : " + PlayerPrefs.GetInt("highScore").ToString();
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(1);
    }
}
