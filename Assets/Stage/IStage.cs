using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStage {
	PatternData[] Patterns { get; }

	int getMaxWallCount();

	PatternData nextPattern();

	void buildPattern(List<GameObject> walls, PatternData pattern);
}
