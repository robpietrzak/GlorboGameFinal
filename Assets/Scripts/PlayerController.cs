using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 3.0f;
    public int maxHealth = 5;
    public float timeInvincible = 2.0f;
    public int health { get {   return currentHealth;   }}
    int currentHealth;

    bool isInvincible;
    float invincibleTimer;

    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    public AudioClip hurtSound;

    public GameObject heart1;
    public GameObject heart2;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        audioSource = GetComponent<AudioSource>();
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if(isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if(invincibleTimer < 0)
                isInvincible = false;
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + 3.0f * horizontal * Time.deltaTime;
        position.y = position.y + 3.0f * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void ChangeHealth(int amount)
    {
        if(amount < 0)
        {
            if(isInvincible)
                return;
            isInvincible = true;
            invincibleTimer = timeInvincible;
            PlaySound(hurtSound);
            heart1.gameObject.SetActive(false);
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
        if(currentHealth == 0)
        {
            SceneManager.LoadScene("LoseScene");
            Destroy(this.gameObject);
        }
    }
}
