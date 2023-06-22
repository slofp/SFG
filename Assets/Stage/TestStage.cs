using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStage : IStage {
	private readonly PatternData[] patterns = new PatternData[] {
		new PatternData(
			new BreakWallData(
				new Vector3(0, -0.4f, 10f),
				new Vector3(4, 1, 5)
			),
			new BreakWallData(
				new Vector3(0, 1.8f, 10f),
				new Vector3(4, 1, 5)
			),
			new BreakWallData(
				new Vector3(2.1f, 1f, 11.25f),
				new Vector3(1, 2, 2.5f)
			),
			new BreakWallData(
				new Vector3(-2.1f, 1f, 8.75f),
				new Vector3(1, 2, 2.5f)
			),

			new BreakWallData(
				new Vector3(0, -0.4f, 30f),
				new Vector3(4, 1, 5)
			),
			new BreakWallData(
				new Vector3(0, 1.8f, 30f),
				new Vector3(4, 1, 5)
			),
			new BreakWallData(
				new Vector3(-2.1f, 1f, 31.25f),
				new Vector3(1, 2, 2.5f)
			),
			new BreakWallData(
				new Vector3(2.1f, 1f, 28.75f),
				new Vector3(1, 2, 2.5f)
			),

			new BreakWallData(
				new Vector3(0f, 0f, 40f),
				new Vector3(4, 0.5f, 0.5f)
			),
			new BreakWallData(
				new Vector3(0f, 2f, 40f),
				new Vector3(4, 0.5f, 0.5f)
			),
			new BreakWallData(
				new Vector3(-1.75f, 1f, 40f),
				new Vector3(0.5f, 2f, 0.5f)
			)
		),
		new PatternData(
			new BreakWallData(
				new Vector3(0f, 0f, 10f),
				new Vector3(4, 0.5f, 0.5f)
			),
			new BreakWallData(
				new Vector3(0f, 2f, 10f),
				new Vector3(4, 0.5f, 0.5f)
			),
			new BreakWallData(
				new Vector3(1.75f, 1f, 10f),
				new Vector3(0.5f, 2f, 0.5f)
			),

			new BreakWallData(
				new Vector3(0f, 0f, 25f),
				new Vector3(4, 0.5f, 0.5f)
			),
			new BreakWallData(
				new Vector3(0f, 2f, 25f),
				new Vector3(4, 0.5f, 0.5f)
			),
			new BreakWallData(
				new Vector3(-1.75f, 1f, 25f),
				new Vector3(0.5f, 2f, 0.5f)
			),

			new BreakWallData(
				new Vector3(0f, 0f, 40f),
				new Vector3(4, 0.5f, 0.5f)
			),
			new BreakWallData(
				new Vector3(0f, 2f, 40f),
				new Vector3(4, 0.5f, 0.5f)
			),
			new BreakWallData(
				new Vector3(-1.75f, 1f, 40f),
				new Vector3(0.5f, 2f, 0.5f)
			),
			new BreakWallData(
				new Vector3(1.75f, 1f, 40f),
				new Vector3(0.5f, 2f, 0.5f)
			)
		),
		new PatternData(
			new BreakWallData(
				new Vector3(1.75f, 1f, 10f),
				new Vector3(0.5f, 2f, 0.5f)
			),
			new BreakWallData(
				new Vector3(0f, 1f, 10f),
				new Vector3(0.3f, 2f, 0.5f)
			),
			new BreakWallData(
				new Vector3(-1.75f, 1f, 10f),
				new Vector3(0.5f, 2f, 0.5f)
			),

			new BreakWallData(
				new Vector3(1.5f / 2, 1f, 25f),
				new Vector3(0.3f, 2f, 0.5f)
			),
			new BreakWallData(
				new Vector3(-1.5f / 2, 1f, 25f),
				new Vector3(0.3f, 2f, 0.5f)
			),

			new BreakWallData(
				new Vector3(1.75f, 1f, 44f),
				new Vector3(0.5f, 2f, 0.5f)
			),
			new BreakWallData(
				new Vector3(0f, 1f, 44f),
				new Vector3(0.3f, 2f, 0.5f)
			),
			new BreakWallData(
				new Vector3(-1.75f, 1f, 44f),
				new Vector3(0.5f, 2f, 0.5f)
			)
		),
		new PatternData(
			new BreakWallData(
				new Vector3(-0.1f, 1f, 10f),
				new Vector3(0.25f, 2f, 0.5f)
			),
			new BreakWallData(
				new Vector3(-0.6f, 1f, 10f),
				new Vector3(0.25f, 2f, 0.5f)
			),
			new BreakWallData(
				new Vector3(-1.1f, 1f, 10f),
				new Vector3(0.25f, 2f, 0.5f)
			),
			new BreakWallData(
				new Vector3(-1.6f, 1f, 10f),
				new Vector3(0.25f, 2f, 0.5f)
			),

			new BreakWallData(
				new Vector3(0.1f, 1f, 21f),
				new Vector3(0.25f, 2f, 0.5f)
			),
			new BreakWallData(
				new Vector3(0.6f, 1f, 21f),
				new Vector3(0.25f, 2f, 0.5f)
			),
			new BreakWallData(
				new Vector3(1.1f, 1f, 21f),
				new Vector3(0.25f, 2f, 0.5f)
			),
			new BreakWallData(
				new Vector3(1.6f, 1f, 21f),
				new Vector3(0.25f, 2f, 0.5f)
			),

			new BreakWallData(
				new Vector3(-0.1f, 1f, 32f),
				new Vector3(0.25f, 2f, 0.5f)
			),
			new BreakWallData(
				new Vector3(-0.6f, 1f, 32f),
				new Vector3(0.25f, 2f, 0.5f)
			),
			new BreakWallData(
				new Vector3(-1.1f, 1f, 32f),
				new Vector3(0.25f, 2f, 0.5f)
			),
			new BreakWallData(
				new Vector3(-1.6f, 1f, 32f),
				new Vector3(0.25f, 2f, 0.5f)
			),

			new BreakWallData(
				new Vector3(0.1f, 1f, 43f),
				new Vector3(0.25f, 2f, 0.5f)
			),
			new BreakWallData(
				new Vector3(0.6f, 1f, 43f),
				new Vector3(0.25f, 2f, 0.5f)
			),
			new BreakWallData(
				new Vector3(1.1f, 1f, 43f),
				new Vector3(0.25f, 2f, 0.5f)
			),
			new BreakWallData(
				new Vector3(1.6f, 1f, 43f),
				new Vector3(0.25f, 2f, 0.5f)
			)
		),
	};

	public PatternData[] Patterns => patterns;

	private static System.Random rand = new System.Random();

	public void buildPattern(List<GameObject> walls, PatternData pattern) {
		var breakWallDatas = rand.Next(0, 2) == 0 ? pattern.BreakWallDatas : pattern.ReversedBreakWallDatas;
		for (int i = 0; i < breakWallDatas.Length; i++) {
			var wall = walls[i];
			var data = breakWallDatas[i];
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
		return Patterns[rand.Next(0, Patterns.Length)];
	}
}