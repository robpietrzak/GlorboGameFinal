using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    private float timeLeft = 2.0f;

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            if((SceneManager.GetActiveScene().buildIndex + 1) != null)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                Destroy(this.gameObject);
            }
        }
    }
}
