using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SceneChangeButtonEvent : MonoBehaviour {

	[SerializeField]
	GameObject transitionObject;

	[SerializeField]
	string changeSceneName;

	[SerializeField]
	Color color = Color.white;

	// Start is called before the first frame update
	void Start() {
	}

	// Update is called once per frame
	void Update() {
	}

	public void OnClick() {
		var o = Instantiate(transitionObject);

		o.GetComponent<SceneChangeTransition>().PanelColor = color;
		o.GetComponent<SceneChangeTransition>().sceneName = changeSceneName;
	}
}
