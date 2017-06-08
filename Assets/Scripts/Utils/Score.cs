using UnityEngine;
using System;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int points = 0;
    private int highScore = 0;

    void Start()
    {
        GameObject.FindGameObjectWithTag("highscore").GetComponent<Text>().text = getBestScore().ToString();
        this.highScore = PlayerPrefs.GetInt("High Score");
    }

    public void Update()
    {

    }

    /// <summary>
    /// add/remove points to current score
    /// </summary>
    public void addPoints(int amount)
    {
        points += amount;
        GameObject.FindGameObjectWithTag("scoreText").GetComponent<Text>().text = getCurrentPoints();
        saveIfBestScore();
        GameObject.FindGameObjectWithTag("highscore").GetComponent<Text>().text = getBestScore().ToString();
        GameObject.FindGameObjectWithTag("score_").GetComponent<Text>().text = this.points.ToString();
    }

    /// <summary>
    /// return string of points in min 3 chars
    /// </summary>
    public string getCurrentPoints()
    {
        string return_ = points.ToString();
        int end = 3 - return_.Length;
        for (int i = 0; i < end; i++)
        {
            return_ = "0" + return_;
        }
        return return_;
    }

    public static int getBestScore()
    {
        return PlayerPrefs.GetInt("High Score");
    }

    public void saveIfBestScore()
    {
        if (points > PlayerPrefs.GetInt("High Score"))
            PlayerPrefs.SetInt("High Score", points);
    }
}