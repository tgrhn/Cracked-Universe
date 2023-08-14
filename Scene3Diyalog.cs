using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene3Diyalog : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ekran, first, second, third, fourth, fifth, sixth;
    public float hit;
    public bool isTrue;
    void Start()
    {
        isTrue = false;
        hit = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isTrue)
        {
            hit += 1;
        }
        if (isTrue)
        {
            switch (hit)
            {
                case 0:
                    ekran.SetActive(true);
                    first.SetActive(true);
                    second.SetActive(true);
                    sixth.SetActive(true);
                    break;

                case 1:
                    second.SetActive(false);
                    third.SetActive(true);
                    break;

                case 2:
                    first.SetActive(false);
                    third.SetActive(false);
                    fourth.SetActive(true);
                    break;

                case 3:
                    fourth.SetActive(false);
                    fifth.SetActive(true);
                    break;

                case 4:
                    SceneManager.LoadScene(4);
                    break;
            }
        }
    }
}
