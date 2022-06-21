using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    int score;

    void Start()
    {
        scoreText.text = score.ToString("000000000"); 
    }

    public void IncreaseScore(int increaseAmount)
    {
        score+=increaseAmount;
        scoreText.text = score.ToString("0000000000");
    }
}
