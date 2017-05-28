using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPause : MonoBehaviour {

	bool isPause=false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PushPauseButton(){
		
		if (isPause) {
			isPause = false;
			//GameObject.FindGameObjectWithTag ("PauseDisp").GetComponent<MovePauseBand> ().MoveBandRight ();
			Time.timeScale = 1f;
		} else {
			isPause = true;
			//GameObject.FindGameObjectWithTag ("PauseDisp").GetComponent<MovePauseBand> ().MoveBandLeft ();
			Time.timeScale = 0;
		}
	}
}
