using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWalls : MonoBehaviour {

	public GameObject wall;

	GameObject[] walls = new GameObject[2];

	float zPosition = 50;

	float clearWallz = -50;

	float speed = 1f;

	float xPosition = 0; // debug

	// Start is called before the first frame update
	void Start() {
		for (int i = 0; i < walls.Length; i++) {
			walls[i] = wallGenerate(i);
		}
	}

	GameObject getMaxGameObject() {
		if (walls[0].gameObject.transform.position.z > walls[1].gameObject.transform.position.z) {
			return walls[0];
		}
		return walls[1];
	}

	// Update is called once per frame
	void Update() {
		for (int i = 0; i < walls.Length; i++) {
			var w = walls[i];
			w.gameObject.transform.position -= new Vector3(0, 0, speed);
			if (w.gameObject.transform.position.z <= clearWallz) {
				
				w.gameObject.transform.position = new Vector3(xPosition * i, 0, zPosition);
			}
		}
	}

	GameObject wallGenerate(int i) {
		return Instantiate(wall, new Vector3(xPosition * i, 0, zPosition * i), Quaternion.identity);
	}
}
