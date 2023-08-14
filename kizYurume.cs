using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kizYurume : MonoBehaviour
{
    public Transform target;
    private float speed = 1f;
    public Animator animator;
    SceneScript sc; 
    // Start is called before the first frame update
    void Start()
    {
        sc = GameObject.Find("player").GetComponent<SceneScript>();
        transform.position = new Vector3(-16, 0.1f, 0);
        target.transform.position = new Vector3(-0.5f, 0.1f,0f);
        animator.SetBool("isWalking", true);
    } 

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x==-0.5f)
        {
            animator.SetBool("isWalking", false);
            sc.isTrue = true;
        }
        else
        {
            sc.isTrue = false;
        }
        var step = Time.deltaTime * speed;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}
