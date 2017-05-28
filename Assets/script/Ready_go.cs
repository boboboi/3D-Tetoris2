using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ready_go : MonoBehaviour {

	private GameObject gameobject_bg;
	private GameObject gameobject_ready;
	private GameObject gameobject_go;

	private float last_time;
	Text text;

	// Use this for initialization
	void Start () {
		//gameobject_bg    = GameObject.FindGameObjectWithTag ("readygo_bg");
		//gameobject_ready = GameObject.FindGameObjectWithTag ("readygo_ready");
		gameobject_go    = this.gameObject;
		//text = GetComponent<Text> ();
		last_time = Time.realtimeSinceStartup;
		//Group.count = 0;
		GameObject.FindGameObjectWithTag ("FadePanel").GetComponent<FadeManager> ().setFadeInFlg(true);
	}
	
	// Update is called once per frame
	void Update () {
		//if( (Time.realtimeSinceStartup-last_time) > 2 ){
		//	text.text = "GO!!";
		//}

		// フェードイン完了していたら、

		// key入力
		if( (Time.realtimeSinceStartup-last_time) > 2 ){
		//if( GameObject.FindGameObjectWithTag ("FadePanel").GetComponent<FadeManager> ().IsFinishFadeIn() ){
			// Spawn next Group
			//GameObject.FindGameObjectWithTag ("Spawner").GetComponent<Spawner> ().spawnNext (Random.Range(0, 7));
			//Destroy (gameobject_bg);
			//Destroy (gameobject_ready);
			Destroy (gameobject_go);
		}
	}
}
