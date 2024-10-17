using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    private TextMeshProUGUI scoreText;
    private int score;

    private void Awake()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        score = 0;

        scoreText.text = "SCORE: " + score;
    }

    public void IncrementScore()
    {
        score += 10;
        scoreText.text = "SCORE: " + score;
    }
}
