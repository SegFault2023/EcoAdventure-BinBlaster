using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CountdownTimer2 : MonoBehaviour
{
    [SerializeField] TMP_Text countdownText;
    [SerializeField] TMP_Text goText;
    [SerializeField] float countdownTime = 3f;

    void Start()
    {
        StartCoroutine(CountdownCoroutine());
    }

    IEnumerator CountdownCoroutine()
    {
        goText.gameObject.SetActive(false);

        while (countdownTime > 0)
        {
            int seconds = Mathf.FloorToInt(countdownTime % 60);
            countdownText.text = string.Format("{0}", seconds);
            yield return new WaitForSeconds(1f);
            countdownTime -= 1f;
        }

        countdownText.gameObject.SetActive(false);
        goText.gameObject.SetActive(true);

        SceneManager.LoadScene("Level2");

    }
}
