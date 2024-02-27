using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;

    public float increaseInterval = 1f;

    private float timer = 0f;

    [SerializeField]
    TMP_Text scoreText;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= increaseInterval)
        {
            score++;
            timer = 0f;
        }

        scoreText.text = score + "";
    }

    public void incrementScore(int value)
    {
        score += value;
    }
}
