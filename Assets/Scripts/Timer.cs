using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public float timeLeft = 10.0f;
    public Text startText; // used for showing countdown from 3, 2, 1 


    void Update()
    {
        timeLeft -= Time.deltaTime;
        startText.text = (timeLeft).ToString("0");
        if (timeLeft < 0)
        {
            if((SceneManager.GetActiveScene().buildIndex + 1) != null)
                 SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}