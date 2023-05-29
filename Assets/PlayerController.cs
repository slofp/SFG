using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour, IReverse {

	public GravityStateStore stateStore;

	Rigidbody rigidbody;

	float speed = 400;

	// Start is called before the first frame update
	void Start() {
		rigidbody = gameObject.GetComponent<Rigidbody>();
	}

	private bool isLeftKey => Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
	private bool isRightKey => Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);

	private void FixedUpdate() {
		var velocityVec =
			stateStore.state == GravityState.Top ? TopStateControl()
			: stateStore.state == GravityState.Left ? LeftStateControl()
			: stateStore.state == GravityState.Right ? RightStateControl()
			: BottomStateControl();

		rigidbody.velocity = velocityVec;
	}

	private Vector3 BottomStateControl() {
		var velocityVec = new Vector3(0, rigidbody.velocity.y, rigidbody.velocity.z);
		if (isLeftKey) {
			velocityVec.x = -speed * Time.deltaTime;
		}
		else if (isRightKey) {
			velocityVec.x = speed * Time.deltaTime;
		}
		return velocityVec;
	}

	private Vector3 TopStateControl() {
		var velocityVec = new Vector3(0, rigidbody.velocity.y, rigidbody.velocity.z);
		if (isRightKey) {
			velocityVec.x = -speed * Time.deltaTime;
		}
		else if (isLeftKey) {
			velocityVec.x = speed * Time.deltaTime;
		}
		return velocityVec;
	}

	private Vector3 LeftStateControl() {
		var velocityVec = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z);
		if (isRightKey) {
			velocityVec.y = -speed * Time.deltaTime;
		}
		else if (isLeftKey) {
			velocityVec.y = speed * Time.deltaTime;
		}
		return velocityVec;
	}

	private Vector3 RightStateControl() {
		var velocityVec = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z);
		if (isLeftKey) {
			velocityVec.y = -speed * Time.deltaTime;
		}
		else if (isRightKey) {
			velocityVec.y = speed * Time.deltaTime;
		}
		return velocityVec;
	}

	private float movingXLimit = 1.5f;
	private float movingYLimit = 1.5f;
	private float YPadding = 0.2f;

	// Update is called once per frame
	void Update() {
		if (
			(stateStore.state == GravityState.Bottom || stateStore.state == GravityState.Top) &&
			gameObject.transform.position.x <= -movingXLimit) {
			stateStore.state = GravityState.Left;
		}
		else if (
			(stateStore.state == GravityState.Bottom || stateStore.state == GravityState.Top) &&
			gameObject.transform.position.x >= movingXLimit) {
			stateStore.state = GravityState.Right;
		}
		else if (
			(stateStore.state == GravityState.Left || stateStore.state == GravityState.Right) &&
			gameObject.transform.position.y <= YPadding) {
			stateStore.state = GravityState.Bottom;
		}
		else if (
			(stateStore.state == GravityState.Left || stateStore.state == GravityState.Right) &&
			gameObject.transform.position.y - YPadding >= movingYLimit) {
			stateStore.state = GravityState.Top;
		}
	}

	public void Reverse() {
		throw new System.NotImplementedException();
	}
}
