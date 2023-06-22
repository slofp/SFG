using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWallData {

	public Vector3 Position { get; private set; }

	public Vector3 Scale { get; private set; }

	public AnimateWallData AnimateData { get; private set; } = null;

	public BreakWallData(Vector3 position, Vector3 scale) {
		Position = position;
		Scale = scale;
	}

	public BreakWallData(Vector3 position, Vector3 scale, AnimateWallData animateData) : this(position, scale) {
		AnimateData = animateData;
	}

	public BreakWallData(BreakWallData data) : this(data.Position, data.Scale, data.AnimateData) {}
}
