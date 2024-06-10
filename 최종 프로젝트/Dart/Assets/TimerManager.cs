using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour
{
    public float gameTime = 60f; // 게임 제한 시간
    public Text timerText; // 타이머를 표시할 텍스트 UI
    public GameObject gameOverPanel; // 게임 종료 시 표시할 패널
    public Text finalScoreText; // 최종 점수를 표시할 텍스트 UI

    private bool isGameOver = false;

    void Start()
    {
        gameOverPanel.SetActive(false); // 게임 시작 시 종료 패널 비활성화
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
        timerText.text = "남은 시간 : " + Mathf.Ceil(gameTime).ToString();
    }

    void EndGame()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);
        finalScoreText.text = "최종 점수 : " + ScoreManager.instance.GetScore().ToString() +"\nR을 누르면 게임을 다시 시작합니다.";
        Time.timeScale = 0; // 게임 일시정지
    }

    void RestartGame()
    {
        Time.timeScale = 1; // 게임 다시 시작
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
