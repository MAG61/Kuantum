using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralMenu : MonoBehaviour
{
    GameObject pauseMenu;
    void Start()
    {
        pauseMenu = GameObject.Find("PauseMenu");
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeSelf)
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
