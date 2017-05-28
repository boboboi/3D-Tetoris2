using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallManager : MonoBehaviour {

	private static int max = 1000;
	private static int min = 10;

	public static int lastFall;
	public static int speed;

	public static bool fallblock() {
		//if ( ((int)(Time.realtimeSinceStartup * 1000) - lastFall) >= speed)
		if ( ((int)(Time.time * 1000) - lastFall) >= speed)
			return true;

		return false;
	}

	public static void setLastfall() {
		//lastFall = (int)(Time.realtimeSinceStartup * 1000);
		lastFall = (int)(Time.time * 1000);
	}

	// Use this for initialization
	void Start () {
		speed = max;
	}
	
	// Update is called once per frame
	void Update () {
		speed = max * (LevelManager.max - LevelManager.level) / LevelManager.max;
		if (speed < min)
			speed = min;
	}
}
