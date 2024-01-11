using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private static int score;

    [SerializeField]
    private int incrementQuantity = 1;

    [SerializeField]
    private int decrementQuantity = 2;

    [SerializeField]
    private TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "Score : " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score : " + score.ToString();

        if(score > PlayerPrefs.GetInt("highScore"))
        {
            PlayerPrefs.SetInt("highScore", score);
        }
            
    }

    public void incrementScore() 
    {
        score = score + incrementQuantity;
    }


    public void decrementScore()
    {
        score = score - decrementQuantity;
    }

    public static int getScore() { return score; }
}
