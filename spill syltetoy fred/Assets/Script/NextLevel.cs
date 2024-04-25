using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public string forigeScene;
    public string denneScenen;
    public static NextLevel instance;
    public List <string> scener;
    private void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            sjekkScene();
        }
    }
    public void sjekkScene()
    {
        if (denneScenen != null)
        {
            forigeScene = denneScenen;
        }
        Scene currentScene = SceneManager.GetActiveScene();
        denneScenen = currentScene.name;
    }
}
