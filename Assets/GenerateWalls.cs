using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWalls : MonoBehaviour {

	public GameObject wall;

	GameObject[] walls = new GameObject[3];

	float zPosition = 49.9f;

	float clearWallz = -50;

	float speed = 25f;

	float xPosition = 0; // debug

	// Start is called before the first frame update
	void Start() {
		for (int i = 0; i < walls.Length; i++) {
			walls[i] = wallGenerate(i);
		}
	}

	GameObject getMaxGameObject() {
		var res = walls[0];

		for (int i = 1; i < walls.Length; i++) {
			if (res.gameObject.transform.position.z < walls[i].gameObject.transform.position.z) {
				res = walls[i];
			}
		}
		
		return res;
	}

	void fixWalls() {
		var index = Array.IndexOf(walls, getMaxGameObject());

		for (int i = index; i < index + walls.Length - 1; i++) {
			var gm1 = walls[i % walls.Length];
			var gm2 = walls[(i + 1) % walls.Length];
			if (gm1.gameObject.transform.position.z > gm2.gameObject.transform.position.z + zPosition) { 
				gm1.gameObject.transform.position = new Vector3(xPosition * i, 0, gm2.gameObject.transform.position.z + zPosition);
			}
		}
	}

	// Update is called once per frame
	void Update() {
		for (int i = 0; i < walls.Length; i++) {
			var w = walls[i];
			w.gameObject.transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
			if (w.gameObject.transform.position.z <= clearWallz) {
				
				w.gameObject.transform.position = new Vector3(xPosition * i, 0, getMaxGameObject().gameObject.transform.position.z + zPosition);
			}
		}

		fixWalls();
	}

	GameObject wallGenerate(int i) {
		return Instantiate(wall, new Vector3(xPosition * i, 0, zPosition * i), Quaternion.identity);
	}
}
