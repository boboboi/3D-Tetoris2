using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBottun : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MoveBottunUP(){
		iTween.MoveTo (this.gameObject, iTween.Hash ("y", 30, "time", 1));
	}
}
