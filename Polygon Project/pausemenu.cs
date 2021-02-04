using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    public static bool gameIsPause = false;
    public GameObject pauseMenuUI;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPause)
            {
                resume();
            }
            else
            {
                pause();
            }
        }  
    }
    public void resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPause = false;
        Cursor.visible = false;
    }

    void pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPause = true;
        Cursor.visible = true;
    }

    public void restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("game");
    }

    public void backToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("startMenu");
    }
}
