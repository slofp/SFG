using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GravityStateStore))]
public class GravityManage : MonoBehaviour {

	private GravityState prevState;

	private GravityStateStore stateStore;

	// this is bottom gravity
	private static readonly Vector3 firstGravity = firstGravity = new Vector3(Physics.gravity.x, Physics.gravity.y, Physics.gravity.z);

	// Start is called before the first frame update
	void Start() {
		stateStore = GetComponent<GravityStateStore>();
		prevState = stateStore.state;
		Physics.gravity = firstGravity;
	}

	// Update is called once per frame
	void Update() {
		if (prevState == stateStore.state) return;

		if (stateStore.state == GravityState.Bottom) {
			Physics.gravity = new Vector3(firstGravity.x, firstGravity.y, firstGravity.z);
		}
		else if (stateStore.state == GravityState.Top) {
			Physics.gravity = new Vector3(firstGravity.x, -firstGravity.y, firstGravity.z);
		}
		else if (stateStore.state == GravityState.Left) {
			Physics.gravity = new Vector3(firstGravity.y, firstGravity.x, firstGravity.z);
		}
		else if (stateStore.state == GravityState.Right) {
			Physics.gravity = new Vector3(-firstGravity.y, firstGravity.x, firstGravity.z);
		}

		prevState = stateStore.state;
	}
}
