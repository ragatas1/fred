using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlukkeOppFlereTingScript : MonoBehaviour
{
    public float antallTing;
    public float antallhar;
    public GameObject txt;
    bool paTing;
    bool paEnd;
    GameObject theCurrentThing;
    GameObject endZone;
    GameObject test;
    NextLevel nextLevel;
    // Start is called before the first frame update
    void Start()
    {
        test = GameObject.FindGameObjectWithTag("logikk");
        nextLevel = test.GetComponent<NextLevel>();
        endZone = GameObject.FindGameObjectWithTag("endZone");
        endZone.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (paTing)
        {
            if (Input.GetButton("Interact"))
            {
                antallhar = antallhar + 1;
                Destroy(theCurrentThing);
                paTing = false;
            }
        }
        if (paEnd)
        {
            if (Input.GetButton("Interact"))
            {
                SceneManager.LoadScene(nextLevel.nesteScene);
            }
        }
        if (paTing || paEnd)
        {
            txt.SetActive(true);
        }
        else
        {
            txt.SetActive(false);
        }
        if (antallhar == antallTing)
        {
            endZone.SetActive (true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ting")
        {
            theCurrentThing = other.gameObject;
            paTing = true;
        }
        else if (other.tag == "endZone")
        {
            paEnd = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "ting")
        {
            paTing = false;
        }
        else if (other.tag == "endZone")
        {
            paEnd = false;
        }
    }
}
