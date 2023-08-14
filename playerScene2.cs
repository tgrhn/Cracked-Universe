using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerScene2 : MonoBehaviour
{
    gameManager gm;
    Vector3 velocity;
    public float speed;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("gameManager").GetComponent<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        atlaVeyaAtlama();
        if (transform.position.x >= -2.4)
        {
            animator.SetBool("falling", true);
        }
        SceneSettings();
    }
    public void SceneSettings()
    {
        if (transform.position.y < -6)
        {
            SceneManager.LoadScene(3);
        }
    }
    public void atlaVeyaAtlama()
    {
        if (gm.atlaButton == true)
        {
            velocity = new Vector3(0.5f, 0, 0);
            animator.SetBool("Walk", true);
            transform.position += velocity * speed * Time.deltaTime;
        }
    }
}
