using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DispHighScore : MonoBehaviour {

	Text text;

	// Use this for initialization
	void Start () {
		text = this.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void WriteHighScore(){
		text.text = "High Score " + HighScore.LoadHighScore();
	}
}
