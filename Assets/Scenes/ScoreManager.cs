using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;   // global score
    public TextMeshProUGUI scoreText; // TMP reference

    void Start()
    {
        score = 0; // reset score when game starts
        UpdateScoreUI();
    }

    public static void AddPoints(int points)
    {
        score += points;

        // Find ScoreManager in scene and update UI
        if (FindObjectOfType<ScoreManager>() != null)
        {
            FindObjectOfType<ScoreManager>().UpdateScoreUI();
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score.ToString();
    }
}
