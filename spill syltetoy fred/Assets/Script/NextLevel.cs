using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public GameObject falseProphet;

    void OnLevelWasLoaded(Scene scene, LoadSceneMode mode)
    {
        falseProphet = GameObject.FindGameObjectWithTag("logikk");
        Destroy(falseProphet);
    }
    private void OnLevelWasLoaded()
    {
        falseProphet = GameObject.FindGameObjectWithTag("logikk");
        Destroy(falseProphet);
    }
    private void Start()
    {
        SceneManager.sceneLoaded += OnLevelLoaded;
        StartCoroutine(starten());
    }
    IEnumerator starten()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.tag = "logikkTrue";
        DontDestroyOnLoad(gameObject);
    }
}
