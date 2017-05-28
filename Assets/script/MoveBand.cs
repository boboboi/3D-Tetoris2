using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBand : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MoveBandRight(){
		iTween.MoveTo (this.gameObject, iTween.Hash ("x", 200, "time", 1));
	}
}
