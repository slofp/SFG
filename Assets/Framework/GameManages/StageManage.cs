using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManage : MonoBehaviour {

	public GameObject breakWall;

	public int stageIndex = 0;

	private static readonly IStage[] stages = { new TestStage() };

	public GenerateWalls generateWalls;

	private IStage CurrentStage => stages[stageIndex];

	private Dictionary<GameObject, List<GameObject>> breakWalls = new();

	private int currentPattrnLength = 0;

	private GameObject lastGameObject = null;

	// Start is called before the first frame update
	void Start() {
		
	}

	private bool first = false;

	// Update is called once per frame
	void Update() {
		if (!first) {
			first = true;
			WallInitialize(generateWalls.getMaxGameObject());
		}
	}

	public void WallInitialize(GameObject wallObject) {
		FillRequireStageWalls(wallObject);
		var pattern = CurrentStage.nextPattern();
		CurrentStage.buildPattern(breakWalls[wallObject], pattern);
		currentPattrnLength = pattern.BreakWallDatas.Length;

		setParentBreakWalls(wallObject, currentPattrnLength);
		setVisibleWalls(wallObject, currentPattrnLength, true);
	}

	public void WallFinalize(GameObject wallObject) {
		if (!breakWalls.ContainsKey(wallObject)) return;
		setVisibleWalls(wallObject, breakWalls[wallObject].Count, false);
	}

	void setParentBreakWalls(GameObject wall, int length) {
		for (int i = 0; i < length; i++) {
			breakWalls[wall][i].transform.position = wall.transform.position + breakWalls[wall][i].transform.position;
			breakWalls[wall][i].transform.parent = wall.transform;
		}
	}

	void setVisibleWalls(GameObject wall, int length, bool visible) {
		for (int i = 0; i < length; i++) {
			breakWalls[wall][i].SetActive(visible);
		}
	}

	void FillRequireStageWalls(GameObject wallObject) {
		var count = CurrentStage.getMaxWallCount();
		if (!breakWalls.ContainsKey(wallObject)) {
			breakWalls.Add(wallObject, new());
		}

		if (breakWalls[wallObject].Count < count) {
			GenerateBreakWalls(breakWalls[wallObject], count - breakWalls[wallObject].Count);
		}
	}

	public void NextStage() {
		stageIndex++;
		//FillRequireStageWalls();
	}

	void GenerateBreakWalls(List<GameObject> breakWalls, int count) {
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
