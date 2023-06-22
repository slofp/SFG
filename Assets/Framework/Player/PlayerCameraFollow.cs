using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraFollow : MonoBehaviour {

	public GameObject stageCamera;
	public GameObject resultWindow;

	public GravityStateStore stateStore;

	Vector3 cameraOffset;

	Vector3 currentEuler;

	float rotate = 5;

	float rotateSpeed = 10;

	float limitX = 1.2f;

	float limitMaxY = 1.6f;
	float limitMinY = 0.5f;

	GravityState prevState = GravityState.Bottom;
	float currentRotateZ = 0;
	float moveRotateZ = 0;
	float endRotateZ = 0;

	/**
	 * time = [0 - 1]
	 */
	float easeOutBack(float time) {
		float c1 = 1.70158f;
		float c3 = c1 + 1;

		return 1 + c3 * Mathf.Pow(time - 1, 3) + c1 * Mathf.Pow(time - 1, 2);
	}

	// Start is called before the first frame update
	void Start() {
		cameraOffset = new Vector3(
			stageCamera.transform.position.x - gameObject.transform.position.x,
			stageCamera.transform.position.y - gameObject.transform.position.y,
			stageCamera.transform.position.z - gameObject.transform.position.z
		);

		currentEuler = new Vector3(
			stageCamera.transform.rotation.eulerAngles.x,
			stageCamera.transform.rotation.eulerAngles.y,
			stageCamera.transform.rotation.eulerAngles.z
		);
	}

	public Vector3 gravityRotateVector(GravityState state, Vector3 current) {
		if (state == GravityState.Top) {
			return new Vector3(-current.x, current.y, current.z);
		}
		else if (state == GravityState.Left) {
			return new Vector3(current.y, -current.x, current.z);
		}
		else if (state == GravityState.Right) {
			return new Vector3(current.y, current.x, current.z);
		}

		return new Vector3(current.x, current.y, current.z);
	}

	private float rotateZEaseTime = 0;
	float currentGravityRotateZ(GravityState state) {
		if (prevState != state) {
			moveRotateZ = gravityRotateZ(prevState, state);
			endRotateZ = endRotateZ + moveRotateZ;
			rotateZEaseTime = 0;
			prevState = state;
		}

		/*if (state == GravityState.Top) {
			return new Vector3(-current.x, current.y, current.z);
		}
		else if (state == GravityState.Left) {
			return new Vector3(current.y, -current.x, current.z);
		}
		else if (state == GravityState.Right) {
			return new Vector3(current.y, current.x, current.z);
		}

		return new Vector3(current.x, current.y, current.z);*/

		if ((moveRotateZ < 0 && currentRotateZ <= endRotateZ) || (moveRotateZ >= 0 && currentRotateZ >= endRotateZ)) {
			return endRotateZ;
		}

		rotateZEaseTime += Time.deltaTime;
		currentRotateZ = (endRotateZ - moveRotateZ) + moveRotateZ * easeOutBack(rotateZEaseTime * 2);
		return currentRotateZ;
	}

	public float gravityRotateZ(GravityState prevState, GravityState state) {
		if (prevState == GravityState.Bottom && state == GravityState.Top) {
			return 180;
		}
		else if (prevState == GravityState.Top && state == GravityState.Bottom) {
			return -180;
		}

		if (prevState == GravityState.Left && state == GravityState.Right) {
			return 180;
		}
		else if (prevState == GravityState.Right && state == GravityState.Left) {
			return -180;
		}

		if (prevState == GravityState.Bottom && state == GravityState.Left) {
			return -90;
		}
		else if (prevState == GravityState.Bottom && state == GravityState.Right) {
			return 90;
		}

		if (prevState == GravityState.Top && state == GravityState.Left) {
			return 90;
		}
		else if (prevState == GravityState.Top && state == GravityState.Right) {
			return -90;
		}

		if (prevState == GravityState.Left && state == GravityState.Bottom) {
			return 90;
		}
		else if (prevState == GravityState.Left && state == GravityState.Top) {
			return -90;
		}

		if (prevState == GravityState.Right && state == GravityState.Bottom) {
			return -90;
		}
		else if (prevState == GravityState.Right && state == GravityState.Top) {
			return 90;
		}

		return 0;
	}

	Vector3 gravityPositionOffset(GravityState state) {
		if (state == GravityState.Top) {
			return new Vector3(0, -1.6f, 0);
		}
		else if (state == GravityState.Left) {
			return new Vector3(0.8f, -0.8f, 0);
		}
		else if (state == GravityState.Right) {
			return new Vector3(-0.8f, -0.8f, 0);
		}

		return new Vector3(0, 0, 0);
	}

	Vector3 cuttingPosition(Vector3 vector) {
		return new Vector3(Mathf.Clamp(vector.x, -limitX, limitX), Mathf.Clamp(vector.y, limitMinY, limitMaxY), vector.z);
	}

	private float getRotate() {
		return rotate * Time.deltaTime * rotateSpeed;
	}

	private float easeOutCubic(float time) {
		return 1 - Mathf.Pow(1 - time, 3);
	}

	private float reverseTimer = 0;
	private bool isReversing = false;

	public void reversePosition() {
		reverseTimer = 0.1f;
		isReversing = true;
	}

	private const float cameraMoveDecay = 0.9999f;

	private const float playerLimitX = 1.5f;
	private const float playerLimitY = 1.6f;
	private const float YPadding = 0.2f;

	private Vector3 getReversedFinalPosition(GravityState state) {
		if (state == GravityState.Bottom) {
			return new Vector3(gameObject.transform.position.x, YPadding, gameObject.transform.position.z);
		}
		else if (state == GravityState.Top) {
			return new Vector3(gameObject.transform.position.x, playerLimitY + YPadding, gameObject.transform.position.z);
		}
		else if (state == GravityState.Right) {
			return new Vector3(playerLimitX, gameObject.transform.position.y, gameObject.transform.position.z);
		}
		else {
			return new Vector3(-playerLimitX, gameObject.transform.position.y, gameObject.transform.position.z);
		}
	}

	private void FixedUpdate() {
		if (resultWindow.activeSelf) return;
		var playerPosition = gameObject.transform.position;
		if (isReversing) {
			if (
				(stateStore.state == GravityState.Bottom && playerPosition.y <= YPadding) ||
				(stateStore.state == GravityState.Top && playerPosition.y >= playerLimitY + YPadding) ||
				(stateStore.state == GravityState.Left && playerPosition.x <= -playerLimitX) ||
				(stateStore.state == GravityState.Right && playerPosition.x >= playerLimitX)
			) {
				isReversing = false;
			}
			playerPosition = getReversedFinalPosition(stateStore.state);
		}
		var cameraGoalPos = cuttingPosition(cameraOffset + gravityPositionOffset(stateStore.state) + playerPosition);
		float rm;
		if (Time.deltaTime > reverseTimer) {
			rm = reverseTimer;
			reverseTimer = 0;
		}
		else {
			rm = Time.deltaTime;
			reverseTimer -= Time.deltaTime;
		}
		stageCamera.transform.position += (cameraGoalPos - stageCamera.transform.position) *
			(1 - Mathf.Pow(1 - cameraMoveDecay, Time.deltaTime)) * Mathf.Pow(0.1f, rm * 120);

		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
			currentEuler.z -= getRotate();
		}
		else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
			currentEuler.z += getRotate();
		}
		else if (currentEuler.z != 0) {
			if (currentEuler.z < 0) {
				currentEuler.z += getRotate();
				if (currentEuler.z > 0) currentEuler.z = 0;
			}
			else {
				currentEuler.z -= getRotate();
				if (currentEuler.z < 0) currentEuler.z = 0;
			}
		}
		currentEuler.z = Mathf.Clamp(currentEuler.z, -rotate, rotate);

		var resultRotateEuler = new Vector3(currentEuler.x, currentEuler.y, currentEuler.z + currentGravityRotateZ(stateStore.state));

		stageCamera.transform.rotation = Quaternion.Euler(gravityRotateVector(stateStore.state, resultRotateEuler));
	}

	// Update is called once per frame
	void Update() {
	}
}
