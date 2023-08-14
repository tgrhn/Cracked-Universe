using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesBehavior : MonoBehaviour
{

    public float moveSpeed;
    public float xmin;
    public float xmax;
    public int health; 

    Rigidbody2D rb;
    int direction = 1;

    void Start()
    {
        health = 100;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);

        if (transform.position.x <= xmin)
        {
            transform.position = new Vector2(xmin, transform.position.y);
            direction = 1;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (transform.position.x >= xmax)
        {
            transform.position = new Vector2(xmax, transform.position.y);
            direction = -1;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (health <= 0)
        {
            Invoke("Destroy", 0.1f); gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "fire"|| collision.gameObject.tag == "water")
        {
            health -= 34;
        }

    } 
    public void Destroy()
    {
        gameObject.SetActive(false);
    }
}
