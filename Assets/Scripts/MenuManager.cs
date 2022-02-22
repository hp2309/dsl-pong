using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject main;
    public GameObject options;
    SceneHandler sm;
    private void Awake()
    {
        sm = GameObject.FindGameObjectWithTag("sceneHandler").GetComponent<SceneHandler>();
        main.SetActive(true);
        options.SetActive(false);
    }
    
    public void gotoOptions()
    {
        main.SetActive(false);
        options.SetActive(true);
    }
    public void gotoMain()
    {
        options.SetActive(false);
        main.SetActive(true);
    }
    public void gotoGame()
    {
        sm.gotoGame();
    }

    public void exitGame()
    {
        print("quitting Game");
        sm.exitGame();
    }
}
