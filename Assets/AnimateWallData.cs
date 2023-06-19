using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateWallData {
	public Vector3 ToPosition { get; private set; }
	public float AnimateDelay { get; private set; }

	public AnimateWallData(Vector3 toPosition, float animateDelay = 0) {
		ToPosition = toPosition;
		AnimateDelay = animateDelay;
	}
}
