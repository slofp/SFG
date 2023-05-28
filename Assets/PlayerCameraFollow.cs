using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraFollow : MonoBehaviour, IReverse {

	public GameObject stageCamera;

	Vector3 cameraOffset;

	Vector3 currentEuler;

	float rotate = 5;

	float rotateSpeed = 10;

	float limitX = 1.33f;

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

	public void reverseRotate() {
		
	}

	Vector3 cuttingXPosition(Vector3 vector) {
		return new Vector3(Mathf.Clamp(vector.x, -limitX, limitX), vector.y, vector.z);
	}

	private float getRotate() {
		return rotate * Time.deltaTime * rotateSpeed;
	}

	private void FixedUpdate() {
		stageCamera.transform.position = cuttingXPosition(cameraOffset + gameObject.transform.position);

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
		stageCamera.transform.rotation = Quaternion.Euler(currentEuler);
	}

	// Update is called once per frame
	void Update() {
		
	}

	public void Reverse()
	{
		throw new System.NotImplementedException();
	}
}
