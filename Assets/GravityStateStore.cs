using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityStateStore : MonoBehaviour {

	public GameObject resultWindow;

	public GravityState state { get; set; }

	// Start is called before the first frame update
	void Start() {
		state = GravityState.Bottom;
	}

	// Update is called once per frame
	void Update() {
		if (resultWindow.activeSelf) return;
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) {
			Reverse();
			UnityEngine.Debug.Log(state);
		}
	}

	void FixedUpdate() {
		
	}

	void Reverse() {
		if (state == GravityState.Bottom) {
			state = GravityState.Top;
		}
		else if (state == GravityState.Top) {
			state = GravityState.Bottom;
		}
		else if (state == GravityState.Left) {
			state = GravityState.Right;
		}
		else if (state == GravityState.Right) {
			state = GravityState.Left;
		}
	}
}
