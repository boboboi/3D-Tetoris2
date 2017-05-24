using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result_Score : MonoBehaviour {

	Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		text.text = "Score:" + ScoreManager.score;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
