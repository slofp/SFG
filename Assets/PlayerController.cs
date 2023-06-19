using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {
	public GravityStateStore stateStore;

	private new Rigidbody rigidbody;

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

	private const float xLimit = 1.5f;
	private const float yLimit = 1.6f;
	private const float addPosition = 0.02f;

	private float movingXLimit = xLimit - addPosition;
	private float movingYLimit = yLimit - addPosition;
	private float YPadding = 0.2f;

	private float roundDigit = 100;

	// Update is called once per frame
	void Update() {
		stateCheck();

		gameObject.transform.position = new Vector3(
			Mathf.Clamp(gameObject.transform.position.x, -xLimit, xLimit),
			Mathf.Clamp(gameObject.transform.position.y, -yLimit + YPadding, yLimit + YPadding),
			-3.5f
		);
	}

	void stateCheck() {
		if (
			(stateStore.state == GravityState.Bottom || stateStore.state == GravityState.Top) &&
			Mathf.Round(gameObject.transform.position.x * roundDigit) / roundDigit <= -movingXLimit) {
			gameObject.transform.position += getAddMovingPosition(stateStore.state);
			stateStore.state = GravityState.Left;
		}
		else if (
			(stateStore.state == GravityState.Bottom || stateStore.state == GravityState.Top) &&
			Mathf.Round(gameObject.transform.position.x * roundDigit) / roundDigit >= movingXLimit) {
			gameObject.transform.position += getAddMovingPosition(stateStore.state);
			stateStore.state = GravityState.Right;
		}
		else if (
			(stateStore.state == GravityState.Left || stateStore.state == GravityState.Right) &&
			Mathf.Round(gameObject.transform.position.y * roundDigit) / roundDigit <= YPadding) {
			gameObject.transform.position += getAddMovingPosition(stateStore.state);
			stateStore.state = GravityState.Bottom;
		}
		else if (
			(stateStore.state == GravityState.Left || stateStore.state == GravityState.Right) &&
			Mathf.Round(gameObject.transform.position.y * roundDigit) / roundDigit - YPadding >= movingYLimit) {
			gameObject.transform.position += getAddMovingPosition(stateStore.state);
			stateStore.state = GravityState.Top;
		}
	}

	Vector3 getAddMovingPosition(GravityState state) {
		if (stateStore.state == GravityState.Bottom) {
			return new Vector3(0, addPosition, 0);
		}
		else if (stateStore.state == GravityState.Top) {
			return new Vector3(0, -addPosition, 0);
		}
		else if (stateStore.state == GravityState.Left) {
			return new Vector3(addPosition, 0, 0);
		}
		else {
			return new Vector3(-addPosition, 0, 0);
		}
	}
}
