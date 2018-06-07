using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;
    public static int score;
    public static int highScore;
    

	void Start () {
        score = 0;
        scoreText.text = score.ToString();
	}
	
	void Update () {
        scoreText.text = score.ToString();
        
    }


}
