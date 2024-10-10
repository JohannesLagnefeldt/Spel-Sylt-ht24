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

        ScoreText.text = "Score: " + score.ToString();

        if (time <= -1)
        {
            SceneManager.LoadScene(0);
        }
    }
}
