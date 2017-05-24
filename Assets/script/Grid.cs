using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {
	
	// The Grid itself
	public static int w = 10;
	public static int h = 20;
	public static int d = 10;
	public static Transform[,,] grid = new Transform[w, h, d];

	public GameObject gameobject;

	public static Vector3 roundVec3(Vector3 v) {
		return new Vector3(Mathf.Round(v.x), Mathf.Round(v.y), Mathf.Round(v.z));
	}

	public static bool insideBorder(Vector3 pos) {
		return ((int)pos.x >= 0 &&
			(int)pos.z >= 0 &&
			(int)pos.x < w &&
			(int)pos.y >= 0 &&
			(int)pos.z < d );
	}

	public static void deleteRow(int y) {
		//grid [x, y, z].gameObject.GetComponent<ParticleSystem> ().Play ();

		for (int x = 0; x < w; ++x) {
			for (int z = 0; z < d; ++z) {
				if (grid [x, y, z] != null) {

					//削除するオブジェクトのマテリアルを獲得
					Material material = grid [x, y, z].gameObject.GetComponent<Renderer> ().material;

					//透明ブロックを作成する
					//GameObject gameobject = (GameObject)Resources.Load ("Prefab/Particl_cube_prefab");
					GameObject gameobject = (GameObject)Resources.Load ("Particl_cube_prefab", typeof(GameObject));
					GameObject particl_block = Instantiate(gameobject, (new Vector3(x, y, z)), Quaternion.identity);

					//オブジェクトにマテリアルをアタッチ
					particl_block.GetComponent<ParticleSystemRenderer>().material = material;

					Destroy (grid [x, y, z].gameObject);
					grid [x, y, z] = null;

				}
			}
		}
	}

	public static void decreaseRow(int y) {
		for (int x = 0; x < w; ++x) {
			for (int z = 0; z < d; ++z) {
				if (grid [x, y, z] != null) {
					// Move one towards bottom
					grid [x, y - 1, z] = grid [x, y, z];
					grid [x, y, z] = null;

					// Update Block position
					grid [x, y - 1, z].position += new Vector3 (0, -1, 0);
				}
			}
		}
	}

	public static void decreaseRowsAbove(int y) {
		for (int i = y; i < h; ++i)
			decreaseRow(i);
	}

	public static bool isRowFull(int y) {

		switch (MainCamera.current_view) {
		case (int)MainCamera.View.A:
		case (int)MainCamera.View.C:
			for (int x = 0; x < w; ++x)
				if (!isBlockAtDepthZ (x, y))
					return false;
			return true;
		case (int)MainCamera.View.B:
		case (int)MainCamera.View.D:
			for (int z = 0; z < w; ++z)
				if (!isBlockAtDepthX (y, z))
					return false;
			return true;
		default:
			return false;
		}
	}

	public static bool isBlockAtDepthZ(int x, int y) {
			for (int z = 0; z < d; ++z)
				if (grid[x, y, z] != null)
				return true;
		return false;
	}

	public static bool isBlockAtDepthX(int y, int z) {
		for (int x = 0; x < d; ++x)
			if (grid[x, y, z] != null)
				return true;
		return false;
	}

	public static void deleteFullRows() {
		for (int y = 0; y < h; ++y) {
			if (isRowFull(y)) {
				deleteRow(y);
				decreaseRowsAbove(y+1);
				--y;
				ScoreManager.delete_line++;
			}
		}
		ScoreManager.setScore ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
