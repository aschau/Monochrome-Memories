using UnityEngine;
using System.Collections;

public class jumpObject : baseObject {
    public float multiplier = 1.5f;

    // Use this for initialization
	public override void Start () {
        base.particleColor = new Color32(255, 40, 40, 255);
	}
}
