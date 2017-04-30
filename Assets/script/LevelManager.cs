using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	public static int level;
	public static int max=10;

	Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		level = 1;		
	}
	
	// Update is called once per frame
	void Update () {
		level = (ScoreManager.score / 100) + 1;
		if (level > max)
			level = max;
		text.text = ":" + level;
	}
}
