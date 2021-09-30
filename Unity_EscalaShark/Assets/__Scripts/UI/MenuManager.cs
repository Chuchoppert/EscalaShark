using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour 
{
    public void MN_BotonStart()
    {
        Debug.Log("1");
        SceneManager.LoadScene(1);
    }
    public void BotonQuit()
    {
        Application.Quit();
    }
    public void BotonMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void BotonRestart(string escena)
    {
        SceneManager.LoadScene(escena);
    }
}