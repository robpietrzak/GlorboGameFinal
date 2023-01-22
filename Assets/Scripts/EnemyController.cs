using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Transform target;
    Vector2 moveDirection;
    public float speed = 3.0f;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Glorbo").transform;
    }

    void Update()
    {
        if(target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //rb.rotation = angle;
            moveDirection = direction;
        }
    }
    
    void FixedUpdate()
    {
        if(target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * speed;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController >();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }
}