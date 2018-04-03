using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

    Text scoreString;
    int score;

	// Use this for initialization
	void Start () {
        scoreString = GetComponent<Text>();
        scoreString.text = score.ToString();
	}
	
    public void AddPoints (int points) {
        score += points;
        scoreString.text = score.ToString();
    }
}
