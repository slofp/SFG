using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultEvent : MonoBehaviour {

	public float clearTime = 60;

	public string gameOverText = "Game Over";
	public string stageClearText = "Stage Clear!";
	public TextMeshProUGUI resultStateTextDisplay;

	public TextMeshProUGUI resultTimeTextDisplay;

	public TextMeshProUGUI resultScoreTextDisplay;

	private float incrementTime = 0;
	private uint incrementScore = 0;

	private float finalTime = 0;
	private uint finalScore = 0;

	private const int counterTime = 3;
	private float progressTime = counterTime;

	// Start is called before the first frame update
	void Start() {
		
	}

	// Update is called once per frame
	void Update() {
		if (progressTime >= counterTime) {
			resultScoreTextDisplay.text = scoreFormat(finalScore);
			resultTimeTextDisplay.text = timeFormat(finalTime);
		}
		else {
			progressTime += Time.deltaTime;
			resultScoreTextDisplay.text = scoreFormat((uint) Math.Round(incrementScore * progressTime));
			resultTimeTextDisplay.text = timeFormat(incrementTime * progressTime);
		}
	}

	public void ResetResult() {
		gameObject.SetActive(false);
		incrementScore = 0;
		incrementTime = 0;
		finalScore = 0;
		finalTime = 0;
		resultScoreTextDisplay.text = scoreFormat(0);
		resultTimeTextDisplay.text = timeFormat(0);
	}

	string timeFormat(float time) {
		return string.Format("{0:00.00}s", time);
	}

	string scoreFormat(uint score) {
		return string.Format("{0:000,000}", score);
	}

	public void StartResult(float time, uint score) {
		if (time >= clearTime) {
			resultStateTextDisplay.text = stageClearText;
		}
		else {
			resultStateTextDisplay.text = gameOverText;
		}

		finalScore = score;
		finalTime = time;
		incrementScore = score / counterTime;
		incrementTime = time / counterTime;
		progressTime = 0;
		gameObject.SetActive(true);
	}
}
