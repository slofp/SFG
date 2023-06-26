using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[RequireComponent(typeof(PostProcessVolume))]
public class PostProcessManager : MonoBehaviour {

	// Start is called before the first frame update
	void Start() {
		gameObject.SetActive(ConfigStore.isEnablePostProcess);
	}

	// Update is called once per frame
	void Update() {
		
	}
}
