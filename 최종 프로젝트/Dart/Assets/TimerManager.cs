using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour
{
    public float gameTime = 60f; // ���� ���� �ð�
    public Text timerText; // Ÿ�̸Ӹ� ǥ���� �ؽ�Ʈ UI
    public GameObject gameOverPanel; // ���� ���� �� ǥ���� �г�
    public Text finalScoreText; // ���� ������ ǥ���� �ؽ�Ʈ UI

    private bool isGameOver = false;

    void Start()
    {
        gameOverPanel.SetActive(false); // ���� ���� �� ���� �г� ��Ȱ��ȭ
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
        Time.timeScale = 0; // ���� �Ͻ�����
    }

    void RestartGame()
    {
        Time.timeScale = 1; // ���� �ٽ� ����
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
