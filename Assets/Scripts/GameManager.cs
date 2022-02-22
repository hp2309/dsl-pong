using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI tGoal;
    public TextMeshProUGUI tPoint1;
    public TextMeshProUGUI tPoint2;
    public GameObject ball;
    SceneHandler sm;

    public GameObject pausePanel;
    public GameObject optionsMenu;
    public GameObject pauseMenu;
    public bool isGamePaused = false;

    int iGoal = 10;
    int iPoint1 = 0;
    int iPoint2 = 0;

    // Start is called before the first frame update
    void Start()
    {
        sm = GameObject.FindGameObjectWithTag("sceneHandler").GetComponent<SceneHandler>();
        tGoal.text = iGoal.ToString();
        tPoint1.text = iPoint1.ToString();
        tPoint2.text = iPoint2.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isGamePaused)
        {
            resume();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && !isGamePaused)
        {
            pause();
        }
    }

    public void playerScored()
    {
        iPoint1++;
        tPoint1.text = iPoint1.ToString();
        if(iPoint1 == iGoal)
        {
            print("Player Won!!");
        }
    }
    
    public void computerScored()
    {
        iPoint2++;
        tPoint2.text = iPoint2.ToString();
        if(iPoint2 == iGoal)
        {
            print("Computer Won!!");
        }
    }

    public void exitGame()
    {
        Time.timeScale = 1f;
        sm.gotoMenu();
    }

    public void pause()
    {
        pausePanel.SetActive(true);
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
        isGamePaused = true;
        Time.timeScale = 0f;
    }
    public void gotoOptions()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
    
    public void gotoPause()
    {
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void resume()
    {
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
        pausePanel.SetActive(false);
        isGamePaused = false;
        Time.timeScale = 1f;
    }
}
