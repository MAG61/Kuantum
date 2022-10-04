using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
