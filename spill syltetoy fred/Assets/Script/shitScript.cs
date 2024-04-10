using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class shitScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
