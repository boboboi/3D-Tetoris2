using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement; 

public class Group : MonoBehaviour {
	
	// Time since last gravity tick
	public static int t = 0;
	public static int count = 0;
	//public int count = 0;

	private AudioSource sound;

	private int down_count;

	private static int fall_cnt=0;

	bool isValidGridPos() {        
		foreach (Transform child in transform) {
			Vector3 v = Grid.roundVec3(child.position);

			// Not inside Border?
			if (!Grid.insideBorder (v)) 
				return false;

			// Block in grid cell (and not part of same group)?
			if (isBlockAtDept ((int)v.x, (int)v.y, (int)v.z) == true &&
				isAllBlockAtDeptSameParent((int)v.x, (int)v.y, (int)v.z) == false) {
				return false; /* exist other block */
			}
		}
		return true;
	}

	bool isAllBlockAtDeptSameParent(int x, int y, int z) {

		switch (MainCamera.current_view) {
		case (int)MainCamera.View.A:
		case (int)MainCamera.View.C:
			for (int i = 0; i < Grid.d; ++i) {
				if (Grid.grid [x, y, i] != null) {
					if (Grid.grid [x, y, i].parent != transform) {			
						return false;
					}
				}
			}
			return true;
		case (int)MainCamera.View.B:
		case (int)MainCamera.View.D:
			for (int i = 0; i < Grid.d; ++i) {
				if (Grid.grid [i, y, z] != null) {
					if (Grid.grid [i, y, z].parent != transform) {			
						return false;
					}
				}
			}
			return true;
		}
		return false;
	}

	bool isBlockAtDept(int x, int y, int z) {

		switch (MainCamera.current_view) {
		case (int)MainCamera.View.A:
		case (int)MainCamera.View.C:
			for (int i = 0; i < Grid.d; ++i) {
				if (Grid.grid [x, y, i] != null) {
					return true; /* exist block */
				}
			}
			return false;
		case (int)MainCamera.View.B:
		case (int)MainCamera.View.D:
			for (int i = 0; i < Grid.w; ++i) {
				if (Grid.grid [i, y, z] != null) {
					return true; /* exist block */
				}
			}
			return false;
		}
		return false;
	}

	void updateGrid(int x, int z) {
		// Remove old children from grid
		for (int y = 0; y < Grid.h; ++y){

			switch (MainCamera.current_view) {
			case (int)MainCamera.View.A:
			case (int)MainCamera.View.C:
				for (int i = 0; i < Grid.w; ++i) {
					if (Grid.grid[i, y, z] != null){
							if (Grid.grid[i, y, z].parent == transform){
								Grid.grid[i, y, z] = null;
						}
					}
				}
				break;
			case (int)MainCamera.View.B:
			case (int)MainCamera.View.D:
				for (int i = 0; i < Grid.d; ++i) {
					if (Grid.grid[x, y, i] != null){
						if (Grid.grid[x, y, i].parent == transform){
							Grid.grid[x, y, i] = null;
						}
					}
				}
				break;			
			}
		}

		// Add new children to grid
		foreach (Transform child in transform) {
			Vector3 v = Grid.roundVec3(child.position);
			Grid.grid[(int)v.x, (int)v.y, (int)v.z] = child;
		}
	}

	public static Vector3 moveVec3(string key) {

		switch(MainCamera.current_view){
		case (int)MainCamera.View.A:
			if(key=="LeftArrow"){
				return new Vector3(-1,0,0);
			}else{
				return new Vector3(1,0,0);
			}
		case (int)MainCamera.View.B:
			if(key=="LeftArrow"){
				return new Vector3(0,0,-1);
			}else{
				return new Vector3(0,0,1);
			}
		case (int)MainCamera.View.C:
			if(key=="LeftArrow"){
				return new Vector3(1,0,0);
			}else{
				return new Vector3(-1,0,0);
			}
		case (int)MainCamera.View.D:
			if(key=="LeftArrow"){
				return new Vector3(0,0,1);
			}else{
				return new Vector3(0,0,-1);
			}
		}
		return new Vector3(0,0,0);
	}

	// Use this for initialization
	void Start () {

		fall_cnt = 0;
		sound = GetComponent<AudioSource> ();

		// Default position not valid? Then it's game over
		if (!isValidGridPos()) {
			HighScore.SaveHighScore (ScoreManager.getScore());
			GameObject.Find ("CameraRotateObject").GetComponent<MainCamera> ().finishRolling ();
			GameObject.FindGameObjectWithTag ("HighScoreText").GetComponent<DispHighScore> ().WriteHighScore ();
			GameObject.FindGameObjectWithTag ("GameOver/Disp").GetComponent<MoveBand> ().MoveBandRight();
			GameObject.FindGameObjectWithTag ("GameOver/Bottun").GetComponent<MoveBottun> ().MoveBottunUP();
			//SceneManager.LoadScene ("gameover");
			Destroy(gameObject);
		}		
	}

	// Update is called once per frame
	void Update () {

		// Move Left
		if (Input.GetKeyDown (KeyCode.LeftArrow) || (touchManage.swipeL==true) ) { //GetKeyDown
			// Modify position
			transform.position += moveVec3 ("LeftArrow");

			// See if valid
			if (isValidGridPos ())
				// Its valid. Update grid.
				updateGrid ((int)transform.position.x, (int)transform.position.z);
			else
				// Its not valid. revert.
				transform.position -= moveVec3 ("LeftArrow");

			GameObject.FindGameObjectWithTag ("TouchManager").GetComponent<touchManage> ().reset ();
		}
		// Move Right
		else if (Input.GetKeyDown (KeyCode.RightArrow) || (touchManage.swipeR==true) ) {
			// Modify position
			transform.position += moveVec3 ("RightArrow");

			// See if valid
			if (isValidGridPos ())
				// It's valid. Update grid.
				updateGrid ((int)transform.position.x, (int)transform.position.z);
			else
				// It's not valid. revert.
				transform.position -= moveVec3 ("RightArrow");
			
			GameObject.FindGameObjectWithTag ("TouchManager").GetComponent<touchManage> ().reset ();
		}
		// Rotate
		else if ((Input.GetKeyDown (KeyCode.A)) || (Input.GetKeyDown (KeyCode.S)) || (touchManage.touch==true)) {

			if (Input.GetKeyDown (KeyCode.A)) {
				transform.Rotate (0, 0, 90);
			} else {
				transform.Rotate (0, 0, -90);
			}
			

			// See if valid
			if (isValidGridPos ()) {
				// It's valid. Update grid.
				updateGrid ((int)transform.position.x, (int)transform.position.z);
			} else {

				// Move left
				transform.position += moveVec3 ("LeftArrow");
				if (isValidGridPos ()) {
					updateGrid ((int)transform.position.x, (int)transform.position.z);
				} else {
					transform.position -= moveVec3 ("LeftArrow");

					// Move Right
					transform.position += moveVec3 ("RightArrow");
					if (isValidGridPos ()) {
						updateGrid ((int)transform.position.x, (int)transform.position.z);
					} else {
						transform.position -= moveVec3 ("RightArrow");

						// Move left
						transform.position += moveVec3 ("LeftArrow");
						transform.position += moveVec3 ("LeftArrow");
						if (isValidGridPos ()) {
							updateGrid ((int)transform.position.x, (int)transform.position.z);
						} else {
							transform.position -= moveVec3 ("LeftArrow");
							transform.position -= moveVec3 ("LeftArrow");

							// Move Right
							transform.position += moveVec3 ("RightArrow");
							transform.position += moveVec3 ("RightArrow");
							if (isValidGridPos ()) {
								updateGrid ((int)transform.position.x, (int)transform.position.z);
							} else {
								// It's not valid. revert.
								transform.position -= moveVec3 ("RightArrow");
								transform.position -= moveVec3 ("RightArrow");

								if (Input.GetKeyDown (KeyCode.A)) {
									transform.Rotate (0, 0, -90);
								} else {
									transform.Rotate (0, 0, 90);
								}
							}
						}
					}
				}
			}

			GameObject.FindGameObjectWithTag ("TouchManager").GetComponent<touchManage> ().reset ();
		}
		// Move Downwards and Fall
		else if (Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.UpArrow) ||
			FallManager.fallblock()==true || (touchManage.swipeD==true) ) {

			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				down_count = Grid.h;
			} else {
				down_count = 1;
			}

			for (int i = 0; i < down_count; i++) {
				
				// Modify position
				transform.position += new Vector3 (0, -1, 0);

				// See if valid
				if (isValidGridPos ()) {
					// It's valid. Update grid.
					updateGrid ((int)transform.position.x, (int)transform.position.z);

					GameObject.FindGameObjectWithTag ("TouchManager").GetComponent<touchManage> ().reset ();
				} else {

					// It's not valid. revert.
					transform.position += new Vector3 (0, 1, 0);

					fall_cnt++;

					if (fall_cnt == 2) {

						sound.PlayOneShot (sound.clip);

						// Clear filled horizontal lines
						Grid.deleteFullRows ();

						count++;
						if (count == 7) {
							MainCamera.Rotate ();
							count = 0;
						}

						// Spawn next Group
						GameObject.FindGameObjectWithTag ("Spawner").GetComponent<Spawner> ().spawnNext (NextBlock.nextGroupIdx);
						//GameObject.FindGameObjectWithTag ("Spawner").GetComponent<Spawner> ().spawnNext (0);
						GameObject.FindGameObjectWithTag ("NextBlock").GetComponent<NextBlock> ().changeNextBlock ();

						Grid.deleteFullRows (); //回転後に消えていたら消す

						GameObject.FindGameObjectWithTag ("TouchManager").GetComponent<touchManage> ().reset ();

						fall_cnt = 0;

						// Disable script
						enabled = false;

						break;
					} else {
						//無処理
					}
				}

				FallManager.setLastfall ();
			}
		}
	}
}
