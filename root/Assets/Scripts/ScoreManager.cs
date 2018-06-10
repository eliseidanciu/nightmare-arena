using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static int score;
    public static int DEMON_SCORE = 1;
    public static int ORC_SCORE = 2;
    int highScore;

    GameObject scoreObj;
    GameObject highScoreObj;
    Text scoreText;
    Text highScoreText;

    const int GAME_OVER_INDEX = 2;
    const int GAMEPLAY_INDEX = 1;

    void Start () {

        scoreObj = GameObject.FindGameObjectWithTag("Score");
        scoreText = scoreObj.GetComponent<Text>();
        scoreText.text = score.ToString();

        if (SceneManager.GetActiveScene().buildIndex == GAME_OVER_INDEX)
        {
            scoreText.text = "Score: " + score.ToString();
            Debug.Log("Score: " + score.ToString());
            highScoreObj = GameObject.FindGameObjectWithTag("HighScore");
            highScoreText = highScoreObj.GetComponent<Text>();
            CheckHighScore();
        }
        else
        {
            score = 0;
        }
    }
	
	void Update () {
        
        if(SceneManager.GetActiveScene().buildIndex == GAMEPLAY_INDEX)
        {
            scoreText.text = score.ToString();
        }
            
    }

    void CheckHighScore()
    {
        const string PATH = "..\\root\\Assets\\Saves\\highScore.txt";
        int oldHighScore = 0;

        if (File.Exists(PATH))
        {
            Debug.Log("File exists");
            string oldHighScoreString = File.ReadAllText(PATH);
            Int32.TryParse(oldHighScoreString, out oldHighScore);
            Debug.Log("Old HighScore: " + oldHighScore);
        }
        if (score > oldHighScore)
        {
            highScore = score;
            File.WriteAllText(PATH, highScore.ToString());
            Debug.Log("New High Score " + highScore);
        }
        else
        {
            highScore = oldHighScore;
        }
        highScoreText.text = "BEST: " + highScore.ToString();
    }


}
