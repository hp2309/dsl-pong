using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    private static SceneHandler sm;
    // Start is called before the first frame update
    private void Awake()
    {
        sm = this.gameObject.GetComponent<SceneHandler>();
        
        if (GameObject.FindGameObjectsWithTag("sceneHandler").Length != 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void gotoGame()
    {
        SceneManager.LoadScene(1);
    }
    public void gotoMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void gotoOver()
    {
        SceneManager.LoadScene(2);
    }

    public void exitGame()
    {
        Application.Quit();
    }

}
