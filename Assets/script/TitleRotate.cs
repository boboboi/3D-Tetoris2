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

		if (touchManage.swipeL == true){ 
			if (stage [current_stage + 1] == true) {
				MainCameraTitle.Rotate ();
				current_stage += 1;
				GameObject.FindGameObjectWithTag ("TouchManager").GetComponent<touchManage> ().reset ();
			} else {
				GameObject.FindGameObjectWithTag ("TouchManager").GetComponent<touchManage> ().reset ();
				//MainCamera.RotateNG ();
			}
		} else if (touchManage.swipeR == true){
			if( current_stage != 0 ){
				MainCameraTitle.RotateReverse ();
				current_stage -= 1;
				GameObject.FindGameObjectWithTag ("TouchManager").GetComponent<touchManage> ().reset ();
			} else {
				GameObject.FindGameObjectWithTag ("TouchManager").GetComponent<touchManage> ().reset ();
				//MainCamera.RotateNG ();
			}
		}
	}
}
