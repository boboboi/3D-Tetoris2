using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

	private static int degree = 0;

	public static GameObject gobject;

	public static int current_view = (int)View.A;

	public bool finish_flg = false;

	public enum View{
		A,
		B,
		C,
		D
	}
	public View view;

	public static void Rotate() {

		switch (current_view) {
		case (int)View.A:
			degree -= 90;
			current_view = (int)View.B;
			break;
		case (int)View.B:
			degree -= 90;
			current_view = (int)View.C;
			break;
		case (int)View.C:
			degree -= 90;
			current_view = (int)View.D;
			break;
		case (int)View.D:
			degree = 0;
			current_view = (int)View.A;
			break;
		default:
			Debug.Log ("Error Rotate");
			break;
		}

		iTween.RotateTo (gobject, iTween.Hash ("y", degree, "time", 2));

	}

	public static void RotateReverse() {

		switch (current_view) {
		case (int)View.A:
			degree += 90;
			current_view = (int)View.D;
			break;
		case (int)View.B:
			degree = 0;
			current_view = (int)View.A;
			break;
		case (int)View.C:
			degree += 90;
			current_view = (int)View.B;
			break;
		case (int)View.D:
			degree += 90;
			current_view = (int)View.C;
			break;
		default:
			Debug.Log ("Error Rotate");
			break;
		}

		iTween.RotateTo (gobject, iTween.Hash ("y", degree, "time", 2));
	}

	public void finishRolling(){
		finish_flg = true;
	}

	// Use this for initialization
	void Start () {
		current_view = (int)View.A;
		degree = 0;
		gobject = GameObject.Find ("CameraRotateObject");
	}
	
	// Update is called once per frame
	void Update () {
		if (finish_flg == true) {
			this.gameObject.transform.Rotate (0, 1.0f, 0);
		}
	}
}
