using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class FromTitletoNormal : MonoBehaviour {

	//[SerializeField]
	bool fade = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if(touchManagerTitle.touch == true){

			//fade.FadeIn (1, () => {
			//	SceneManager.LoadScene ("mainview");
			//});

			GameObject.FindGameObjectWithTag ("FadePanel").GetComponent<FadeManager> ().setFadeOutFlg(true);

			GameObject.FindGameObjectWithTag ("TouchManager").GetComponent<touchManagerTitle> ().reset ();
		}

		fade = GameObject.FindGameObjectWithTag ("FadePanel").GetComponent<FadeManager> ().IsFinishFadeOut ();
		if (fade) {
			SceneManager.LoadScene ("mainview");
		}
	}
}
