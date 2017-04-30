using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour {

	private GameObject Cam3D;
	private GameObject Cam2D;

	void Start () {
		Cam3D = GameObject.Find("3D Camera");
		Cam2D = GameObject.Find("2D Camera");

		Cam2D.SetActive(false);
	}

	void Update () {
		if(Input.GetKeyDown("space")){
			if(Cam3D.activeSelf){
				Cam3D.SetActive (false);
				Cam2D.SetActive (true);
			}else{
				Cam3D.SetActive (true);
				Cam2D.SetActive (false);
			}
		}
	}
}
