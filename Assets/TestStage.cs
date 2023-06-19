using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStage : IStage {
	private readonly PatternData[] patterns = new PatternData[] {
		new PatternData(
			new BreakWallData(
				new Vector3(0, -0.4f, -10),
				new Vector3(4, 1, 5)
			),
			new BreakWallData(
				new Vector3(0, 1.8f, -10),
				new Vector3(4, 1, 5)
			)
		)
	};

	public PatternData[] Patterns => patterns;

	public void buildPattern(List<GameObject> walls, PatternData pattern) {
		for (int i = 0; i < pattern.BreakWallDatas.Length; i++) {
			var wall = walls[i];
			var data = pattern.BreakWallDatas[i];
			wall.transform.position = data.Position;
			wall.transform.localScale = data.Scale;
		}
	}

	private int max(int x, int y) {
		if (x < y) return y;
		return x;
	}

	public int getMaxWallCount() {
		int res = 0;
		foreach (var pd in Patterns) {
			res = max(res, pd.BreakWallDatas.Length);
		}
		return res;
	}

	public PatternData nextPattern() {
		var rand = new System.Random();
		return Patterns[rand.Next(0, Patterns.Length)];
	}
}