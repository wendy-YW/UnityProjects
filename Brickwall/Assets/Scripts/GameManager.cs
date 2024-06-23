using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] walls;
    public GameObject winPanel;
    public TextMeshProUGUI timeTextTMP;

    // private float startTime;
    // private float endTime;
    private float timeSpent;
    private bool gameWon = false;

    void Start()
{   
    timeSpent=0;
    Time.timeScale = 1;
    // startTime = Time.time;
    winPanel.SetActive(false);
    timeTextTMP=winPanel.GetComponentInChildren<TextMeshProUGUI>();
}

void CheckForWin()
{   
    bool allWallsDestroyed = true;
    foreach (GameObject wall in walls)
    {
        if (wall != null)
        {
            allWallsDestroyed = false;
            break;
        }
    }
    if (allWallsDestroyed)
    {
        gameWon = true;
        ShowWinPanel(timeSpent);
    }
}

void ShowWinPanel(float timeSpent)
{
    winPanel.SetActive(true);
    timeTextTMP.text = "Time: " + timeSpent.ToString("F2");
}

void Update()
{
    if (gameWon)
    {   
        Time.timeScale = 0;
        ShowWinPanel(timeSpent);
    }

    timeSpent += Time.deltaTime;
    CheckForWin();

}

public void QuitGame()  
{   
    Debug.Log("Quit button clicked");
    Application.Quit();
}

public void RestartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

}