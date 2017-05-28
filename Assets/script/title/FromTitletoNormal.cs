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

		//if(touchManagerTitle.touch == true){

			//fade.FadeIn (1, () => {
			//	SceneManager.LoadScene ("mainview");
			//});

			//GameObject.FindGameObjectWithTag ("FadePanel").GetComponent<FadeManager> ().setFadeOutFlg(true);
			//GameObject.FindGameObjectWithTag ("TouchManager").GetComponent<touchManagerTitle> ().reset ();
		//}

		if (OnTouchDown()) {
			GameObject.FindGameObjectWithTag ("FadePanel").GetComponent<FadeManager> ().setFadeOutFlg (true);
		}

		fade = GameObject.FindGameObjectWithTag ("FadePanel").GetComponent<FadeManager> ().IsFinishFadeOut ();
		if (fade) {

			switch( TitleRotate.current_stage ){
			case 1:
				SceneManager.LoadScene ("mainview");
				break;
			default:
				break;
			}

		}
	}

	bool OnTouchDown(){
		if (touchManagerTitle.touch == true) {
			if (0 < Input.touchCount) {
				for (int i = 0; i < Input.touchCount; i++) {
					Touch t = Input.GetTouch (i);
					if (t.phase == TouchPhase.Began) {
						Ray ray = Camera.main.ScreenPointToRay (t.position);
						RaycastHit hit = new RaycastHit ();
						if (Physics.Raycast (ray, out hit)) {
							if (hit.collider.gameObject == this.gameObject) {
								return true;
							} else {
								Debug.Log (hit.collider.gameObject);
							}
						}
					}
				}
			}
		}
		return false;
	}


#if false
	public void PushCube() {
		switch( TitleRotate.current_stage ){
		case 1:
			GameObject.FindGameObjectWithTag ("FadePanel").GetComponent<FadeManager> ().setFadeOutFlg (true);
			stage = TitleRotate.current_stage;
			break;
		default:
			break;
		}
		GameObject.FindGameObjectWithTag ("TouchManager").GetComponent<touchManagerTitle> ().reset ();
	}
#endif
}
