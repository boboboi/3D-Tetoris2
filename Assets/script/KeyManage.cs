using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManage : MonoBehaviour {

	// 長押しフレーム数
	public int presskeyFramesL = 0;
	public int presskeyFramesR = 0;

	// 長押し判定の閾値（フレーム数）
	private int thresholdLong = 10;
	// 軽く押した判定の閾値（フレーム数）
	private int thresholdShort = 1;

	public bool presskeyShortL = false;
	public bool presskeyShortR = false;
	public bool presskeyLongL = false;
	public bool presskeyLongR = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		presskeyFramesL += (Input.GetKey("left")) ? 1 : 0;
		presskeyFramesR += (Input.GetKey("right")) ? 1 : 0;
		if (Input.GetKeyUp ("left")) {
			presskeyFramesL = 0;
			presskeyShortL = false;
			presskeyLongL = false;
		}
		if (Input.GetKeyUp ("right")) {
			presskeyFramesR = 0;
			presskeyShortR = false;
			presskeyLongR = false;
		}

		if(presskeyFramesL != 0){
			if (thresholdLong <= presskeyFramesL) {
				presskeyLongL = true;
				presskeyShortL = false;
			} else if (thresholdShort <= presskeyFramesL) {
				presskeyShortL = true;
			} 
		}

		if(presskeyFramesR != 0){
			if (thresholdLong <= presskeyFramesR) {
				presskeyLongR = true;
				presskeyShortR = false;
			} else if (thresholdShort <= presskeyFramesR) {
				presskeyShortR = true;
			} 
		}
	}
}
