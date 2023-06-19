using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternData {

	private readonly BreakWallData[] breakWallDatas;

	public BreakWallData[] BreakWallDatas => breakWallDatas;

	public PatternData(params BreakWallData[] breakWallDatas) {
		this.breakWallDatas = breakWallDatas;
	}
}