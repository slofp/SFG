using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigStore : MonoBehaviour {

	[SerializeField]
	public static bool isEnablePostProcess = true;

	[SerializeField]
	Toggle toggleEffect;

	public void SetEnablePostProcess(bool value) {
		isEnablePostProcess = value;
	}

	// Start is called before the first frame update
	void Start() {
		toggleEffect.isOn = isEnablePostProcess;
	}

	// Update is called once per frame
	void Update() {
		
	}
}
