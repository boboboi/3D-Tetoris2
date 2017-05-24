using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraTitle : MonoBehaviour {

	private static int degree = 0;
	public static GameObject gobject;

	public static int current_view = (int)View.A;

	public static bool MoveFlg = false;

	//Hashtable table = new Hashtable();

	public enum View{
		A,
		B,
		C,
		D
	}
	public View view;

	public void Rotate() {

		Hashtable table = new Hashtable();

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

		table.Add( "y", degree ); 
		table.Add( "time", 1 );

		table.Add("onstart", "OnStartCallBack");		// コールバック関数名 
		table.Add("onstartparams", "Start");		// コールバック関数に渡す引数 
		table.Add("onstarttarget", gobject );	// コールバック関数を実装しているgameObject. 

		table.Add("oncomplete", "OnCompleteCallback"); 
		table.Add("oncompleteparams", "Complete"); 
		table.Add("oncompletetarget", gobject ); 
		iTween.RotateTo (gobject, table);
	}

	public void RotateReverse() {

		Hashtable table = new Hashtable();

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

		table.Add( "y", degree ); 
		table.Add( "time", 1 );

		table.Add("onstart", "OnStartCallBack");		// コールバック関数名 
		table.Add("onstartparams", "Start");		// コールバック関数に渡す引数 
		table.Add("onstarttarget", gobject );	// コールバック関数を実装しているgameObject. 

		table.Add("oncomplete", "OnCompleteCallback"); 
		table.Add("oncompleteparams", "Complete"); 
		table.Add("oncompletetarget", gobject ); 

		iTween.RotateTo (gobject, table);

	}

	public static bool IsCubeRotate (){
		return MoveFlg;
	}

	// 開始時コールバック 
	//public void OnStartCallBack( string message ) 
	public void OnStartCallBack( ) 
	{ 
		MoveFlg = true;
	} 

	public void OnCompleteCallback( ) 
	{ 
		MoveFlg = false;
	} 

	public void RotateNG() {

		StartCoroutine ("coroutineRotateNG");

	}

	public IEnumerator coroutineRotateNG(){

		Hashtable table = new Hashtable();
		Hashtable table2 = new Hashtable();

		degree -= 5;
		table.Add( "y", degree ); 
		table.Add( "time", 0.2f );

		table.Add("onstart", "OnStartCallBack");		// コールバック関数名 
		table.Add("onstartparams", "Start");		// コールバック関数に渡す引数 
		table.Add("onstarttarget", gobject );	// コールバック関数を実装しているgameObject. 

		table.Add("oncomplete", "OnCompleteCallback"); 
		table.Add("oncompleteparams", "Complete"); 
		table.Add("oncompletetarget", gobject ); 

		iTween.RotateTo (gobject, table);
		yield return new WaitForSeconds(0.2f);

		degree += 5;
		table2.Add( "y", degree ); 
		table2.Add( "time", 0.2f );

		table2.Add("onstart", "OnStartCallBack");		// コールバック関数名 
		table2.Add("onstartparams", "Start");		// コールバック関数に渡す引数 
		table2.Add("onstarttarget", gobject );	// コールバック関数を実装しているgameObject. 

		table2.Add("oncomplete", "OnCompleteCallback"); 
		table2.Add("oncompleteparams", "Complete"); 
		table2.Add("oncompletetarget", gobject ); 

		iTween.RotateTo (gobject, table2);
	}

	public void RotateReverseNG() {

		StartCoroutine ("coroutineRotateReverseNG");

	}

	public IEnumerator coroutineRotateReverseNG(){

		Hashtable table = new Hashtable();
		Hashtable table2 = new Hashtable();

		degree += 5;
		table.Add( "y", degree ); 
		table.Add( "time", 0.2f );

		table.Add("onstart", "OnStartCallBack");		// コールバック関数名 
		table.Add("onstartparams", "Start");		// コールバック関数に渡す引数 
		table.Add("onstarttarget", gobject );	// コールバック関数を実装しているgameObject. 

		table.Add("oncomplete", "OnCompleteCallback"); 
		table.Add("oncompleteparams", "Complete"); 
		table.Add("oncompletetarget", gobject ); 

		iTween.RotateTo (gobject, table);
		yield return new WaitForSeconds(0.2f);

		degree -= 5;
		table2.Add( "y", degree ); 
		table2.Add( "time", 0.2f );

		table2.Add("onstart", "OnStartCallBack");		// コールバック関数名 
		table2.Add("onstartparams", "Start");		// コールバック関数に渡す引数 
		table2.Add("onstarttarget", gobject );	// コールバック関数を実装しているgameObject. 

		table2.Add("oncomplete", "OnCompleteCallback"); 
		table2.Add("oncompleteparams", "Complete"); 
		table2.Add("oncompletetarget", gobject ); 

		iTween.RotateTo (gobject, table2);
	}

	// Use this for initialization
	void Start () {
		current_view = (int)View.A;
		degree = 0;
		gobject = GameObject.Find ("CameraRotateObject");

	}

	// Update is called once per frame
	void Update () {

	}
}
