using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sucanavari : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject water;
    Vector3 velocity;
    public Transform spawnPoint;
    public float bulletSpeed;
    Rigidbody2D rb;
    public float timeRemaining;
    private bool isTrue;
    public int health;

    void Start()
    {
        health = 100;
        isTrue = false;
        timeRemaining = 1.5f;
        bulletSpeed = -500f;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isTrue)
        {
            timeRemaining -= Time.deltaTime;
        }
        if (timeRemaining <= 0)
        {
            timeRemaining = 1.5f;
            isTrue = false;
        }
        if (timeRemaining == 1.5f)
        {
            Attacking();
            isTrue = true;
        }
        if (health <= 0)
        {
            Invoke("Destroy", 0.1f); gameObject.SetActive(false);
        }
    }


    public void Attacking()
    {
        GameObject mermi = Instantiate(water, spawnPoint.position, spawnPoint.rotation);
        mermi.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed * Time.deltaTime, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "fire" || collision.gameObject.tag == "water")
        {
            health -= 34;
        }

    }
    public void Destroy()
    {
        gameObject.SetActive(false);
    }
}
