using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScreen : MonoBehaviour {

	private GameObject gameobject;

	// Use this for initialization
	void Start () {
		gameobject = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = new Vector3 (transform.position.x, 300 + Mathf.Sin (Time.frameCount * 0.05f) * 10, transform.position.z);

		if (Input.GetKeyDown(KeyCode.Mouse0)){
			GameObject.FindGameObjectWithTag ("Spawner").GetComponent<Spawner> ().spawnNext (Random.Range(0, 7));
			Destroy (gameobject);
		}

	}
}
