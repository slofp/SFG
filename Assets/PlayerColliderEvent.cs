using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerColliderEvent : MonoBehaviour {

	public string collisionObjectName = "BreakWall";
	public ScoreStore scoreStore;

	void Start() {
		
	}


	void Update() {
		
	}

	private void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.name.StartsWith(collisionObjectName)) {
			Debug.Log("Collisioin!!!!");
		}
	}
}
