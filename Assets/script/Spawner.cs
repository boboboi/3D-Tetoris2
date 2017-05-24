using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	// Groups
	public GameObject[] groups;
	public Material[] _material;

	public void spawnNext(int i) {
		// Random Index
		int x, y, z;
		Quaternion rotate;

		switch(MainCamera.current_view){
		case (int)MainCamera.View.A:
			x = 0;	
			y = 0;	
			z = Random.Range (-5, 5);
			rotate = Quaternion.Euler(0, 0, 0);
			break;
		case (int)MainCamera.View.B:
			x = Random.Range (-5, 5);	
			y = 0;	
			z = 0;
			rotate = Quaternion.Euler(0, -90, 0);
			break;
		case (int)MainCamera.View.C:
			x = 0;	
			y = 0;	
			z = Random.Range (-5, 5);
			rotate = Quaternion.Euler(0, -180, 0);
			break;
		case (int)MainCamera.View.D:
			x = Random.Range (-5, 5);	
			y = 0;	
			z = 0;
			rotate = Quaternion.Euler(0, -270, 0);
			break;
		default:
			x = 0;	
			y = 0;	
			z = 0;
			rotate = Quaternion.Euler(0, 0, 0);
			break;
		}
			
		// Spawn Group at current Position
		//Instantiate(groups[i],
		GameObject gameobject = Instantiate(groups[i],
			transform.position + (new Vector3(x, y, z)),
				rotate);

		int j = Random.Range (0, _material.Length);
		foreach (Transform child in gameobject.transform) {
			child.GetComponent<Renderer> ().material = _material [j];
		}
	}

	// Use this for initialization
	void Start () {
		// Spawn initial Group
		//spawnNext(Random.Range(0, groups.Length));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
