using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesJumpBehavior : MonoBehaviour
{
    public float jumpForce = 7f;
    public float interval = 1f;
    public float ymax = 5f;
    public int health;
    Vector2 originalPosition;

    Rigidbody2D rb;

    void Start()
    {
        health = 100;
        rb = GetComponent<Rigidbody2D>();
        originalPosition = transform.position;
    }

    void Update()
    {
        if (rb.velocity.y == 0)
        {
            rb.velocity = Vector2.up * Random.Range(3f, 7f);
        }
        
     

        if (health <= 0)
        {
            Invoke("Destroy", 0.1f); gameObject.SetActive(false);
        }
    }

  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "fire")
        {
            health -= 34;
        }
    }
}
