using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternData {

	private readonly BreakWallData[] breakWallDatas;
	private readonly BreakWallData[] reversedBreakWallDatas;

	public BreakWallData[] BreakWallDatas => breakWallDatas;
	public BreakWallData[] ReversedBreakWallDatas => reversedBreakWallDatas;

	public PatternData(params BreakWallData[] breakWallDatas) {
		this.breakWallDatas = breakWallDatas;

		reversedBreakWallDatas = new BreakWallData[breakWallDatas.Length];
		for (int i = 0; i < reversedBreakWallDatas.Length; i++) {
			reversedBreakWallDatas[i] = new BreakWallData(
				new Vector3(-breakWallDatas[i].Position.x, breakWallDatas[i].Position.y, breakWallDatas[i].Position.z),
				new Vector3(breakWallDatas[i].Scale.x, breakWallDatas[i].Scale.y, breakWallDatas[i].Scale.z),
				breakWallDatas[i].AnimateData
			);
		}
	}
}