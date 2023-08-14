using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonScript : MonoBehaviour
{
    gameManager gm;
    public GameObject panel;
    public GameObject reddettin;
    void Start()
    {
        gm = GameObject.Find("gameManager").GetComponent<gameManager>();
    }
    // Start is called before the first frame update
    public void AtlaButton()
    {
        gm.atlaButton = true;
        panel.SetActive(false);
    }
    public void AtlamaButton()
    {
        reddettin.SetActive(true);
    }

    public void yenidenBasla()
    {
        SceneManager.LoadScene(0);
    }
}
