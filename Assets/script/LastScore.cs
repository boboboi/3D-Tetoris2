﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastScore : MonoBehaviour {

	Text text;

	// Use this for initialization
	void Start () {
		text = this.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Score " + ScoreManager.score;
	}
}
