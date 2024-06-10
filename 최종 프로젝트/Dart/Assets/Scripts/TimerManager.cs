using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour
{
    public float gameTime = 60f;
    public Text timerText;
    public GameObject gameOverPanel;
    public Text finalScoreText;

    private bool isGameOver = false;

    void Start()
    {
        gameOverPanel.SetActive(false);
        UpdateTimerText();
    }

    void Update()
    {
        if (!isGameOver)
        {
            gameTime -= Time.deltaTime;
            if (gameTime <= 0)
            {
                gameTime = 0;
                EndGame();
            }
            UpdateTimerText();
        }

        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    void UpdateTimerText()
    {
        timerText.text = "���� �ð� : " + Mathf.Ceil(gameTime).ToString();
    }

    void EndGame()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);
        finalScoreText.text = "���� ���� : " + ScoreManager.instance.GetScore().ToString() +"\nR�� ������ ������ �ٽ� �����մϴ�.";
        Time.timeScale = 0;
    }

    void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
