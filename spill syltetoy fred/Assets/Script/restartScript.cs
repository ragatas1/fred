using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class restartScript : MonoBehaviour
{
    GameObject test;
    NextLevel nextLevel;
    public float ventetid;
    public GameObject bakgrunn;
    // Start is called before the first frame update
    void Start()
    {
        test = GameObject.FindGameObjectWithTag("logikk");
        nextLevel = test.GetComponent<NextLevel>();
        nextLevel.sjekkScene();
        StartCoroutine(restart());
        if (nextLevel.forigeScene == "mgsKopi")
        {
            bakgrunn.SetActive(true);
        }
        else
        {
            bakgrunn.SetActive(false);
        }
    }
    IEnumerator restart()
    {
        yield return new WaitForSeconds(ventetid);
        SceneManager.LoadScene(nextLevel.forigeScene);
    }
}
