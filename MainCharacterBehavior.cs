using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterBehavior : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 2f;
    private float horizontalInput;
    Scene3Diyalog s3d;
    public Transform spawnPoint;
    Attack atck;


    public Animator animator;
 
    private Vector2 originalPosition;
    Rigidbody2D rb;

    void Start()
    {
        atck = GameObject.Find("player").GetComponent<Attack>();
        rb = GetComponent<Rigidbody2D>();
        s3d = GameObject.Find("player").GetComponent<Scene3Diyalog>();

    }

    void Update()
    {
        // Move left or right
        horizontalInput = Input.GetAxis("Horizontal");
        if((Mathf.Abs(horizontalInput))>0.1)
        {
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }

        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y==0)
        {

            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);

        }


        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            atck.bulletSpeed = -1000f;
        }
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            atck.bulletSpeed = 1000f;
        }

    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "kedi")
        {
            moveSpeed = 0;
            jumpForce = 0;
            s3d.isTrue = true;
        }
    }

    
}
