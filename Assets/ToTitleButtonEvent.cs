using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ToTitleButtonEvent : MonoBehaviour {

	public string loadSceneName;

	// Start is called before the first frame update
	void Start() {
		
	}

	// Update is called once per frame
	void Update() {
		
	}

	public void OnClick() {
		SceneManager.LoadScene(loadSceneName);
	}
}
