using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreStore : MonoBehaviour {
	// Start is called before the first frame update

	public bool stop = false;
	public float time = 0;
	public uint score = 0;
	public float scoreWeight = 0.5f;
	public float scoreTimeBonus = 10;

	private uint scoreIncrement = 0;

	private uint scoreCounter = 0;
	private float countSec = 0;

	public TextMeshProUGUI timeTextDisplay;

	public TextMeshProUGUI scoreTextDisplay;

	private const float minSecound = 60;

	private const float sinTime = 90 / minSecound;

	private const float radPI = Mathf.PI / 180;

	void Start() {
		
	}

	// Update is called once per frame
	void Update() {
		if (stop) return;

		time += Time.deltaTime;
		countSec += Time.deltaTime;
		if (countSec >= 0.01f) {
			score += (uint) scoreCalculation();
			scoreIncrement = score - scoreCounter;
			countSec = 0;
		}
		if (scoreCounter != score) {
			var inc = (uint)Mathf.FloorToInt(scoreIncrement * Time.deltaTime);
			if (inc == 0) inc = scoreIncrement;
			scoreCounter += inc;
			if (scoreCounter > score) scoreCounter = score;
		}

		timeTextDisplay.text = string.Format("{0:00.00}<space=0.05em><font=\"Waxe SDF\"><size=80%>s", time);
		scoreTextDisplay.text = string.Format("{0:000,000}", scoreCounter);
	}

	float calcOverTimeCount(float time) {
		return Mathf.Floor(time / minSecound);
	}

	float calcSinTimeBonus(float time) {
		return Mathf.Sin(time * sinTime * radPI);
	}

	float calcTimeBonus(float multiplie) {
		return scoreTimeBonus * multiplie;
	}

	float scoreCalculation() {
		var timeOver = calcOverTimeCount(time);
		var timeRemaining = time - timeOver * minSecound;
		var timeSinBonus = calcSinTimeBonus(timeRemaining);

		var finalTimeBonus = calcTimeBonus(timeSinBonus) + calcTimeBonus(timeOver);

		var finalComboBonus = 0f;

		var finalRawScore = finalTimeBonus + finalComboBonus;

		return Mathf.Max(1, Mathf.FloorToInt(finalRawScore * scoreWeight));
	}
}
