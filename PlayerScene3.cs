using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScene3 : MonoBehaviour
{
    Vector3 velocity;
    private Animator animator;
    Rigidbody2D rb;
    float speedAmount = 3f; 
    float jumpAmount = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += velocity * speedAmount * Time.deltaTime;

        if (Input.GetButtonDown("Jump")&& rb.velocity.y == 0)
        {
                rb.AddForce(Vector3.up * jumpAmount, ForceMode2D.Impulse);
        }
        
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (Input.GetAxisRaw("Horizontal") == -1) { 
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

    }
}
