using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyBullets", 3.5f); 
    }

    void DestroyBullets()
    {
        gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy"|| collision.gameObject.tag == "square")
        {
            gameObject.SetActive(false);
        }
        

    }
}
