using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrier : MonoBehaviour
{
    public Animator animator;
    public GameObject text1, text2;
    EnemiesBehavior em;
    // Start is called before the first frame update
    void Start()
    {
        em = GameObject.Find("kýrmýzýcanavar").GetComponent<EnemiesBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if (em.health <= 0)
        {
            animator.SetBool("bariyer", true);
            text1.SetActive(false);
            text2.SetActive(true);
        }
    }
}
