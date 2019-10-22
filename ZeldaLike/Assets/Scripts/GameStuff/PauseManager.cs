using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    private bool isPaused;
    public GameObject pausePanel;

    private void Start()
    {
        isPaused = false;
    }

    private void Update()
    {
        if(Input.GetButtonDown("pause"))
        {
            switchPause();
        }
    }

    public void Resume()
    {
        switchPause();
    }

    public void Quit()
    {
        switchPause();
        SceneManager.LoadScene("StartMenu");
    }

    private void switchPause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
