using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour, IReverse {

	Rigidbody rigidbody;

	float speed = 200;

	// Start is called before the first frame update
	void Start() {
		rigidbody = gameObject.GetComponent<Rigidbody>();
	}

	private void FixedUpdate() {
		var velocityVec = new Vector3(0, rigidbody.velocity.y, rigidbody.velocity.z);
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
			velocityVec.x = -speed * Time.deltaTime;
		}
		else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
			velocityVec.x = speed * Time.deltaTime;
		}

		rigidbody.velocity = velocityVec;
	}

	// Update is called once per frame
	void Update() {
		
	}

	public void Reverse() {
		throw new System.NotImplementedException();
	}
}
