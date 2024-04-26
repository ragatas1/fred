using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class shitScript : MonoBehaviour
{
    NextLevel nextLevel;
    public GameObject test;
    // Start is called before the first frame update
    void Start()
    {
        test = GameObject.FindGameObjectWithTag("logikk");
        nextLevel = test.GetComponent<NextLevel>();
        nextLevel.sjekkScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S) && (Input.GetKey(KeyCode.H)) && (Input.GetKey(KeyCode.I))&& (Input.GetKey(KeyCode.T)))
        {
            SceneManager.LoadScene("TitleScreen");
        } 
    }
}
