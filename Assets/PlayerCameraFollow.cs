using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraFollow : MonoBehaviour, IReverse {

	public GameObject stageCamera;

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

	float currentGravityRotateZ(GravityState state) {
		if (prevState != state) {
			endRotateZ = gravityRotateZ(state);
			moveRotateZ = endRotateZ - currentRotateZ;
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

		currentRotateZ += moveRotateZ / (Time.deltaTime * 3600);
		return currentRotateZ;
	}

	public float gravityRotateZ(GravityState state) {
		if (state == GravityState.Top) {
			return 180;
		}
		else if (state == GravityState.Left) {
			return 270;
		}
		else if (state == GravityState.Right) {
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

	private void FixedUpdate() {
		stageCamera.transform.position = cuttingPosition(cameraOffset + gravityPositionOffset(stateStore.state) + gameObject.transform.position);

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

	public void Reverse()
	{
		throw new System.NotImplementedException();
	}
}
