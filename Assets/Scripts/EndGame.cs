using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{

    private float timeLeft = 2.0f;

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            Application.Quit();
        }
    }
}
