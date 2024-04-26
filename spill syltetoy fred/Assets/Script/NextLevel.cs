using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public string forigeScene;
    public string denneScenen;
    public string nesteScene;
    public static NextLevel instance;
    public List <string> scener;
    [HideInInspector] public bool bane3Checkpoint;
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
        sjekkScene();
        Debug.Log(denneScenen[0]);
    }
    public void bane3()
    {
        sjekkScene();
        if (denneScenen == "Bane3") 
        {
            if (bane3Checkpoint)
            {
                GameObject spiller = GameObject.FindGameObjectWithTag("spillerParent");
                spiller.transform.position = new Vector3(15, -3, -8);
            }
        }
    }
    public void sjekkScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (denneScenen != currentScene.name)
        {
            if (denneScenen != null)
            {
                forigeScene = denneScenen;
            }
            denneScenen = currentScene.name;
        }
        finnNesteScene();
    }
    public void finnNesteScene()
    {
        /*
        if (denneScenen == scener[0]|| denneScenen == scener[1] || denneScenen == scener[2])
        {
            nesteScene = "LevelWin";
        }
        else if (denneScenen == "fanget")
        {
            nesteScene = forigeScene;
        }
        */
        if (forigeScene == scener[0])
        {
            nesteScene = scener[1];
        }
        else if (forigeScene == scener[1])
        {
            nesteScene = scener[2];
        }
        else if (forigeScene == scener[2])
        {
            nesteScene = scener[3];
        }
        else if (denneScenen == scener[3])
        {
            nesteScene = "WinScreen";
        }
    }
}
