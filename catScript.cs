using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catScript : MonoBehaviour

{
    public Rigidbody rb;
    public Animator animator;
    public GameObject text1, text2, text3;
    public float speed = 0.2f;
    private float xmax = 25f, xmin = -18f;
    private float zmax = 14f, zmin = -40f;
    private Vector3 velocity;
    private Vector3 position;
    float smooth = 5.0f;
    playerMovement pm;
    
    // Start is called before the first frame update
    void Start()
    {
        pm = GameObject.Find("Player").GetComponent<playerMovement>();
        rb = GetComponent<Rigidbody>();
        position = new Vector3(xmin, 0, zmax);
        rb.position = position;
        velocity = new Vector3(5f, 0, 0);
        Invoke("firstConversation", 2);

    }

    // Update is called once per frame
    void Update()
    {

        if (position.x > xmax)
        {
            velocity = new Vector3(0, 0, -20f);
            Quaternion target = Quaternion.Euler(0, 180, 0);
            animator.SetBool("run", true);
            text1.SetActive(false);
            text2.SetActive(true);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
            pm.speed = 10;

        }
        position += velocity * speed * Time.deltaTime;
        rb.transform.position = position;

        if (position.z <= zmin)
        {
            text2.SetActive(false);
            text3.SetActive(true);
            gameObject.SetActive(false);
        }
    }
    
    public void firstConversation()
    {
        text1.SetActive(true);
    }

}
