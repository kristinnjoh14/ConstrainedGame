using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public float score;
    public float scoreTwo;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addToScore(float scoreToAdd)
    {
        Debug.Log("SELIR");
        score += scoreToAdd;
        Debug.Log("Score x" + scoreToAdd);

        if (score < 0)
        {
            score = 0;
        }
    }

    public void addToScoreTwo(float scoreToAdd)
    {
        scoreTwo += scoreToAdd;

        if (scoreTwo < 0)
        {
            scoreTwo = 0;
        }
    }
}