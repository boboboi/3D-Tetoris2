using UnityEngine;
using System.Collections;

public class HighScore : MonoBehaviour {

	public const string HIGH_SCORE_KEY = "highScore";

	public static void SaveHighScore(int current_score){

		if (current_score > LoadHighScore ()) {
			PlayerPrefs.SetInt(HIGH_SCORE_KEY, current_score);
			PlayerPrefs.Save();
		}
			
	}

	public static int LoadHighScore(){
		return PlayerPrefs.GetInt(HIGH_SCORE_KEY, -1);
	}


		
}