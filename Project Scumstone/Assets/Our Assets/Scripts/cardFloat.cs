using UnityEngine;
using System.Collections;

public class cardFloat : MonoBehaviour {
    public float amplitude = 10;

    private float originalY;

	// Use this for initialization
	void Start () {
        this.originalY = this.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        if (!this.GetComponent<cardHandler>().beingDragged)
            this.GetComponent<RectTransform>().position = new Vector2(transform.position.x, originalY + (Mathf.Sin(Time.time) * amplitude));
	}

}
