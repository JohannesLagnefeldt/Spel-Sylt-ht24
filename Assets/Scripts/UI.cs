using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UI : MonoBehaviour
{

    [SerializeField] private float playTime;

    public int score = 0;

    [SerializeField] private TMP_Text ScoreText;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private GameObject winWindow;
    [SerializeField] private TMP_Text winText;

    private float time = 0f;

    private void Start()
    {
        time = playTime;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        timeText.text = Mathf.Round(time).ToString();

        ScoreText.text = "score: " + score.ToString();

        if (time < 0.4f)
        {
            GameOver();
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            BackToMenu();
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0f;
        winWindow.SetActive(true);
        winText.text = "final score: " + score.ToString();
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        
        SceneManager.LoadScene(0);
    }
}
