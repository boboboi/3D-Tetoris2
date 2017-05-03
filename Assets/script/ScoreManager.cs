using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static int score;
	public static int delete_line;

	Text text;

	public static void setScore() {
		switch (delete_line) {
		case 1:
			score += 10;
			break;
		case 2:
			score += 50;
			break;		
		case 3:
			score += 100;
			break;
		case 4:
			score += 200;
			break;
		default:
			break;
		}
		delete_line = 0;
	}

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		score = 0;
		delete_line = 0;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = ":" + score;
	}
}
