using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catScene2 : MonoBehaviour
{
    public Rigidbody rb;
    private bool isTrue = true;
    public Animator animator;
    public float speed = 1f;
    private float xmax = -3f, xmin = -13f;
    private Vector3 velocity;
    private Vector3 position;
    float smooth = 5.0f;
    public GameObject text1;
    gameManager gm;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gm = GameObject.Find("gameManager").GetComponent<gameManager>();
        position = new Vector3(xmin, 0, 0);
        rb.position = position;
        velocity = new Vector3(5f, 0, 0);
        gm.playerSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (position.x >= xmax && isTrue)
        {
            velocity = new Vector3(0, 0, 0);
            Quaternion target = Quaternion.Euler(0, 270, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
            animator.SetBool("stop", true);
            text1.SetActive(true);
            Invoke("MovementBack", 1);
        }
        position += velocity * speed * Time.deltaTime;
        rb.transform.position = position;
    }

    public void MovementBack()
    {
        isTrue = false;
        Quaternion target = Quaternion.Euler(0, 90, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        velocity = new Vector3(2f, transform.position.y, 0);
        if (position.x >= -1.2f)
        {
            velocity = new Vector3(1f, -5, 0);
            panel.SetActive(true);
        }
    }
}
