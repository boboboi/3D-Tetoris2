using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchManage : MonoBehaviour {

	private Vector3 touchStartPos;
	private Vector3 touchEndPos;
	private Vector3 WorldStartPos;
	private Vector3 WorldEndPos;
	private int Down_flg=0;

	public static bool swipeR = false;
	public static bool swipeL = false;
	public static bool swipeD = false;
	public int shiftR = 0;
	public int shiftL = 0;
	public static bool touch = false;

	static string Direction;

	void Flick(){

		if (Input.GetKeyDown(KeyCode.Mouse0)){
			touchStartPos = new Vector3(Input.mousePosition.x,
				Input.mousePosition.y,
				Input.mousePosition.z);
			WorldStartPos = Camera.main.ScreenToWorldPoint (touchStartPos);
			Down_flg = 1;
		}

		if(Input.GetKey(KeyCode.Mouse0)){
			touchEndPos = new Vector3(Input.mousePosition.x,
				Input.mousePosition.y,
				Input.mousePosition.z);
			WorldEndPos = Camera.main.ScreenToWorldPoint (touchEndPos);
			GetDirection();
		}

		if(Input.GetKeyUp(KeyCode.Mouse0)){
			touchEndPos = new Vector3(Input.mousePosition.x,
				Input.mousePosition.y,
				Input.mousePosition.z);
			WorldEndPos = Camera.main.ScreenToWorldPoint (touchEndPos);
			GetDirection();
		}
	}

	void GetDirection(){
		float directionX = WorldEndPos.x - WorldStartPos.x;
		float directionY = WorldEndPos.y - WorldStartPos.y;
		float directionZ = WorldEndPos.z - WorldStartPos.z;
		float direction;
		string Direct1, Direct2;

		switch(MainCamera.current_view){
		case (int)MainCamera.View.A:
			direction = directionX;
			Direct1 = "right";
			Direct2 = "left";
			break;
		case (int)MainCamera.View.C:
			direction = directionX;
			Direct1 = "left";
			Direct2 = "right";
			break;
		case (int)MainCamera.View.B:
			direction = directionZ;
			Direct1 = "right";
			Direct2 = "left";
			break;
		case (int)MainCamera.View.D:
			direction = directionZ;
			Direct1 = "left";
			Direct2 = "right";
			break;
		default:
			direction = directionX;
			Direct1 = "right";
			Direct2 = "left";
			break;
		}

		if (Mathf.Abs(directionY) < Mathf.Abs(direction)){
			if (1 < direction){
				//右向きにフリック
				Direction = Direct1;
			}else if (-1 > direction){
				//左向きにフリック
				Direction = Direct2;
			}
			Down_flg = 0;
		}
		else if (Mathf.Abs(direction)<Mathf.Abs(directionY)){
			if (1 < directionY){
				//上向きにフリック
				Direction = "up";
			}else if (-1 > directionY){
				//下向きのフリック
				Direction = "down";
			}
			Down_flg = 0;
		}
		else{
			if (Input.GetKeyUp (KeyCode.Mouse0)) {
				//タッチを検出
				if(Down_flg==1){
					Direction = "touch";
				}
			}
		}
	}

	public void reset() {
		swipeR = false;
		swipeL = false;
		swipeD = false;
		shiftR = 0;
		shiftL = 0;
		touch = false;
		Direction = null;
		WorldStartPos.x = WorldEndPos.x;
		WorldStartPos.y = WorldEndPos.y;
		WorldStartPos.z = WorldEndPos.z;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		Flick ();

		switch (Direction){
		case "up":
			//上フリックされた時の処理
			break;

		case "down":
			//下フリックされた時の処理
			swipeD = true;
			break;

		case "right":
			//右フリックされた時の処理
			swipeR = true;
			shiftR = 1;
			break;

		case "left":
			//左フリックされた時の処理
			swipeL = true;
			shiftL = 1;
			break;

		case "touch":
			//タッチされた時の処理
			touch = true;
			break;
		}
	}
}
