using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullets;
    Vector3 velocity;
    public Transform spawnPoint;
    public float bulletSpeed;
    Rigidbody2D rb;
    public Animator animator;
    public float timeRemaining;
    private bool isTrue;

    void Start()
    {
        isTrue = false;
        timeRemaining = 0.75f;
        bulletSpeed = 1000f;
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
            timeRemaining = 0.75f;
            isTrue = false;
        }
        if (Input.GetKeyDown(KeyCode.Q) && timeRemaining == 0.75f)
        {
            Attacking();
            animator.SetTrigger("fire");
            isTrue = true;
        }
    }


    public void Attacking()
    {
        GameObject mermi = Instantiate(bullets, spawnPoint.position, spawnPoint.rotation);
        mermi.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed * Time.deltaTime, 0f);

    }


}
