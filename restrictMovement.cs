using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restrictMovement : MonoBehaviour
{
    private int  hit;
    public GameObject h1, h2, h3;
    // Start is called before the first frame update
    void Start()
    {
        hit = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -7)
        {
            transform.position = new Vector2(-14.5f, 10);
        }
        if (hit == 1)
        {
            h1.SetActive(false);
        }
        else if (hit == 2)
        {
            h2.SetActive(false);
        }
        else if (hit == 3)
        {
            h3.SetActive(false);
            SceneManager.LoadScene(5);
        }
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.name == "finisher")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (collision.gameObject.tag == "enemy")
        {
            hit += 1;
        }
        if (collision.gameObject.tag == "trap")
        {
            transform.position = new Vector2(-14.5f, 10);
        }
    }
}
