using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartGame : MonoBehaviour
{
    public string sceneName;  //Name of the scene we want it to switch to

    public void LoadLevel()
    {
        SceneManager.LoadScene(sceneName);
    }
    private void Start()
    {
        Cursor.visible = true;

    }
}