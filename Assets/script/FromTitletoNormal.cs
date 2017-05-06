using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class FromTitletoNormal : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(touchManage.touch == true){
			SceneManager.LoadScene ("mainview");
		}
	}
}
