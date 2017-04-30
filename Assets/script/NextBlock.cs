using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextBlock : MonoBehaviour {

	public Sprite[] groups;

	public Image next;
	public static int nextGroupIdx;

	public void changeNextBlock() {
		nextGroupIdx = Random.Range (0, 7);
		next.sprite = groups [nextGroupIdx];
	}

	// Use this for initialization
	void Start () {
		next = GetComponent<Image> ();
		changeNextBlock ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
