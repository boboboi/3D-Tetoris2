using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

	private static int degree = 0;
	private static int i = 1;
	public static GameObject gobject;

	public static int current_view = (int)View.A;

	public enum View{
		A,
		B,
		C,
		D
	}
	public View view;

	public static void Rotate() {

		degree = -90*i;
		iTween.RotateTo (gobject, iTween.Hash ("y", degree, "time", 2));

		switch (i) {
		case 0:
			current_view = (int)View.A;
			i++;
			break;
		case 1:
			current_view = (int)View.B;
			i++;
			break;
		case 2:
			current_view = (int)View.C;
			i++;
			break;
		case 3:
			current_view = (int)View.D;
			i = 0;
			break;
		default:
			Debug.Log ("Error Rotate");
			break;
		}

	}

	// Use this for initialization
	void Start () {
		gobject = GameObject.Find ("CameraRotateObject");
	}
	
	// Update is called once per frame
	void Update () {

	}
}
