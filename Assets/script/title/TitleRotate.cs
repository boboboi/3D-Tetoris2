using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleRotate : MonoBehaviour {

	private const int Stage_Num = 1;
	private static bool[] stage = {true, true, false};
	private static int current_stage;

	// Use this for initialization
	void Start () {
		current_stage = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (MainCameraTitle.IsCubeRotate () == false) {
			
			if (touchManagerTitle.swipeL == true) { 
				if (stage [current_stage + 1] == true) {
					GameObject.FindGameObjectWithTag ("CameraRotateObject").GetComponent<MainCameraTitle> ().Rotate ();
					current_stage += 1;
					GameObject.FindGameObjectWithTag ("TouchManager").GetComponent<touchManagerTitle> ().reset ();
				} else {
					GameObject.FindGameObjectWithTag ("CameraRotateObject").GetComponent<MainCameraTitle> ().RotateNG ();
					GameObject.FindGameObjectWithTag ("TouchManager").GetComponent<touchManagerTitle> ().reset ();
				}
			} else if (touchManagerTitle.swipeR == true) {
				if (current_stage != 0) {
					GameObject.FindGameObjectWithTag ("CameraRotateObject").GetComponent<MainCameraTitle> ().RotateReverse ();
					current_stage -= 1;
					GameObject.FindGameObjectWithTag ("TouchManager").GetComponent<touchManagerTitle> ().reset ();
				} else {
					GameObject.FindGameObjectWithTag ("CameraRotateObject").GetComponent<MainCameraTitle> ().RotateReverseNG ();
					GameObject.FindGameObjectWithTag ("TouchManager").GetComponent<touchManagerTitle> ().reset ();
				}
			}
		} else {
			GameObject.FindGameObjectWithTag ("TouchManager").GetComponent<touchManagerTitle> ().reset ();
		}
	}
}
