using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePauseBand : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void MoveBandRight(){
		iTween.MoveTo (this.gameObject, iTween.Hash ("x", 200, "time", 1));
	}

	public void MoveBandLeft(){
		iTween.MoveTo (this.gameObject, iTween.Hash ("x", -200, "time", 1));
	}
}
