using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FlappGameManager : MonoBehaviour
{
    public int score = 0;
    public int finishScore = 10;
    public Text scoreText;

    GameObject finishMenu;

    private void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        scoreText.text = score.ToString();
        Time.timeScale = 1;

        finishMenu = GameObject.Find("FinishMenu");
        finishMenu.SetActive(false);
    }
    void Update()
    {
        
    }

    public void updateScore()
    {
        score++;
        scoreText.text = score.ToString();
        if (score == finishScore)
        {
            finishMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex));
    }
}
