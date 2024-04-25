using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartScript : MonoBehaviour
{
    GameObject test;
    NextLevel nextLevel;
    public float ventetid;
    // Start is called before the first frame update
    void Start()
    {
        test = GameObject.FindGameObjectWithTag("logikk");
        nextLevel = test.GetComponent<NextLevel>();
        nextLevel.sjekkScene();
        StartCoroutine(restart());
    }
    IEnumerator restart()
    {
        yield return new WaitForSeconds(ventetid);
        SceneManager.LoadScene(nextLevel.forigeScene);
    }
}
