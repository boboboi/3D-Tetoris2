using UnityEngine;
using System.Collections;
using UnityEngine.UI;     //UIを使用可能にする
public class FadeManager : MonoBehaviour {

	float speed = 0.03f;	//透明化の速さ
	float alfa;    				//A値を操作するための変数
	float red, green, blue;		//RGBを操作するための変数
	public bool FadeInFlg=false;
	public bool FadeOutFlg=false;

	void Start () {
		　　　　　//Panelの色を取得
		red   = GetComponent<Image>().color.r;
		green = GetComponent<Image>().color.g;
		blue  = GetComponent<Image>().color.b;
		alfa  = GetComponent<Image>().color.a;
	}

	void Update () {

		if(FadeInFlg){
			GetComponent<Image>().color = new Color(red, green, blue, alfa);
			if (alfa >= 0) {
				alfa -= speed;
			}
		}
		if(FadeOutFlg){
			GetComponent<Image>().color = new Color(red, green, blue, alfa);
			if (alfa <= 1) {
				alfa += speed;
			}
		}

		IsFinishFadeIn ();
		IsFinishFadeOut ();
	}

	public void setFadeInFlg(bool flg){
		FadeInFlg  = flg;
		FadeOutFlg = false;
	}

	public void setFadeOutFlg(bool flg){
		FadeOutFlg = flg;
		FadeInFlg  = false;
	}

	public bool IsFinishFadeIn(){
		if (alfa <= 0) {
			return true;
		} else {
			return false;
		}
	}

	public bool IsFinishFadeOut(){
		if (alfa >= 1) {
			return true;
		} else {
			return false;
		}
	}
}