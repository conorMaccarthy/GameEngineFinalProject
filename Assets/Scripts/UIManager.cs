using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI difficultyText;
    private int score;

    public int activeDifficulty;

    private void Awake()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        score = 0;

        difficultyText = GameObject.Find("DifficultyText").GetComponent<TextMeshProUGUI>();
        difficultyText.text = "DIFFICULTY: EASY";

        activeDifficulty = 0;

        scoreText.text = "SCORE: " + score;
    }

    public void IncrementScore()
    {
        score += 10;
        scoreText.text = "SCORE: " + score;
    }

    public void ResetScore()
    {
        score = 0;
        scoreText.text = "SCORE: " + score;
    }

    public void RaiseDifficulty()
    {
        if (activeDifficulty >= 3) return;
        else 
        { 
            activeDifficulty++;
            UpdateDifficultyText();
        }
    }

    public void LowerDifficulty()
    {
        if (activeDifficulty <= 0) return;
        else 
        { 
            activeDifficulty--;
            UpdateDifficultyText();
        }
    }

    private void UpdateDifficultyText()
    {
        switch (activeDifficulty)
        {
            case 0:
                difficultyText.text = "DIFFICULTY: EASY";
                break;
            case 1:
                difficultyText.text = "DIFFICULTY: MEDIUM";
                break;
            case 2:
                difficultyText.text = "DIFFICULTY: HARD";
                break;
            case 3:
                difficultyText.text = "DIFFICULTY: RANDOM";
                break;
        }
    }
}
