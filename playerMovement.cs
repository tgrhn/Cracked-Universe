using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    Rigidbody rb;
    private float yatay, dikey;
    public Animator animator;
    Vector3 velocity;
    public float speed, rotationSpeed;
    void Start()
    {
        speed = 8f;
        rb =GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
        yatay=Input.GetAxis("Horizontal");
        dikey=Input.GetAxis("Vertical");
        velocity= new Vector3(yatay, 0f, dikey);
        transform.position+= velocity*speed*Time.deltaTime;
        AnimController();
        RotationSettings();
        if (speed >= 10)
        {
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }
    }

    public void AnimController(){
        if((Mathf.Abs(yatay)>=0.1 || Mathf.Abs(dikey)>=0.1) && speed!=10){
            animator.SetBool("Walk",true);
        }
        else{
            animator.SetBool("Walk",false);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Finish")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void RotationSettings(){
       if(velocity != Vector3.zero){
            Quaternion toRotation = Quaternion.LookRotation(velocity, Vector3.up);
            transform.rotation= Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed*Time.deltaTime);
       } 
    }

}
