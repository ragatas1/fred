using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndZone : MonoBehaviour
{
    bool iSone;
    public GameObject txt;
    GameObject test;
    NextLevel nextLevel;
    public bool interaction;
    // Start is called before the first frame update
    void Start()
    {
        test = GameObject.FindGameObjectWithTag("logikk");
        nextLevel = test.GetComponent<NextLevel>();
        nextLevel.sjekkScene();
        txt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (iSone)
        {
            if (interaction)
            {
                if (Input.GetButton("Interact"))
                {
                    SceneManager.LoadScene(nextLevel.nesteScene);
                }
            }
            else
            {
                SceneManager.LoadScene(nextLevel.nesteScene);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        iSone = true;
        txt.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        iSone = false;
        txt.SetActive(false);
    }
}
