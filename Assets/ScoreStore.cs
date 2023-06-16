using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreStore : MonoBehaviour {
	// Start is called before the first frame update

	public float time = 0;
	public uint score = 0;

	public TextMeshProUGUI timeTextDisplay;

	public TextMeshProUGUI scoreTextDisplay;

	void Start() {
		
	}

	// Update is called once per frame
	void Update() {
		time += Time.deltaTime;
		score += 1;

		timeTextDisplay.text = string.Format("{0:00.00}s", time);
		scoreTextDisplay.text = string.Format("{0:000,000}", score);
	}
}
