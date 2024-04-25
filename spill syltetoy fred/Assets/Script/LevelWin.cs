using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelWin : MonoBehaviour
{
    public GameObject txt1;
    public GameObject txt2;
    public float wait;
    public string nextScene;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(paStart());
        txt1.SetActive(false);
        txt2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator paStart()
    {
        yield return new WaitForSeconds(wait);
        txt1.SetActive(true);
        yield return new WaitForSeconds(wait);
        txt2.SetActive(true);
        yield return new WaitForSeconds(wait);
        SceneManager.LoadScene(nextScene);
    }
}
