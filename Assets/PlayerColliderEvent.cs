using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerColliderEvent : MonoBehaviour {

	public string collisionObjectName = "BreakWall";
	public ScoreStore scoreStore;
	public GameObject UIObject;
	public ResultEvent resultWindowEvent;
	public GenerateWalls generateWalls;

	void Start() {
	}


	void Update() {
		
	}

	private void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.name.StartsWith(collisionObjectName)) {
			Debug.Log("Collisioin!!!!");
			scoreStore.stop = true;
			generateWalls.speed = 0;
			UIObject.SetActive(false);
			resultWindowEvent.ResetResult();
			resultWindowEvent.StartResult(scoreStore.time, scoreStore.score);
		}
	}
}
