using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManage : MonoBehaviour {

	public GameObject breakWall;

	public int stageIndex = 0;

	private static readonly IStage[] stages = { new TestStage() };

	public GenerateWalls generateWalls;

	private IStage CurrentStage => stages[stageIndex];

	private List<GameObject> breakWalls = new();

	private int currentPattrnLength = 0;

	// Start is called before the first frame update
	void Start() {
		FillRequireStageWalls();
		var pattern = CurrentStage.nextPattern();
		CurrentStage.buildPattern(breakWalls, pattern);
		currentPattrnLength = pattern.BreakWallDatas.Length;
	}

	private bool first = false;

	// Update is called once per frame
	void Update() {
		if (!first) {
			first = true;
			setParentBreakWalls(generateWalls.getMaxGameObject(), currentPattrnLength);
			setVisibleWalls(currentPattrnLength, true);
		}
	}

	void setParentBreakWalls(GameObject wall, int length) {
		for (int i = 0; i < length; i++) {
			breakWalls[i].transform.position = wall.transform.position + breakWalls[i].transform.position;
			breakWalls[i].transform.parent = wall.transform;
		}
	}

	void setVisibleWalls(int length, bool visible) {
		for (int i = 0; i < length; i++) {
			breakWalls[i].SetActive(visible);
		}
	}

	void FillRequireStageWalls() {
		var count = CurrentStage.getMaxWallCount();
		if (breakWalls.Count < count) {
			GenerateBreakWalls(count - breakWalls.Count);
		}
	}

	public void NextStage() {
		stageIndex++;
		FillRequireStageWalls();
	}

	void GenerateBreakWalls(int count) {
		for (int i = 0; i < count; i++) {
			breakWalls.Add(wallGenerate());
		}
	}

	GameObject wallGenerate() {
		var g = Instantiate(breakWall);
		g.SetActive(false);
		return g;
	}
}
