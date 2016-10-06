using UnityEngine;
using System.Collections;

public class cardHandler : MonoBehaviour {
    private float offsetX;
    private float offsetY;
    private Vector3 origin;
    private Vector2 originalSize;
    private bool beingDragged = false;

	// Use this for initialization
	void Start () {
        this.origin = this.transform.position;
        this.originalSize = this.GetComponent<RectTransform>().sizeDelta;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void beginDrag()
    {
        offsetX = this.transform.position.x - Input.mousePosition.x;
        offsetY = this.transform.position.y - Input.mousePosition.y;
        this.beingDragged = true;
    }

    public void onDrag()
    {
        this.transform.position = new Vector3(Input.mousePosition.x + offsetX, Input.mousePosition.y + offsetY);
    }

    public void endDrag()
    {
        this.transform.position = origin;
        this.beingDragged = false;
        this.GetComponent<RectTransform>().sizeDelta = this.originalSize;
    }

    public void onMouseEnter()
    {
        if (!this.beingDragged)
        {
            this.GetComponent<RectTransform>().sizeDelta = this.originalSize * 2;
        }
    }

    public void onMouseExit()
    {
        if (!this.beingDragged)
        {
            this.GetComponent<RectTransform>().sizeDelta = this.originalSize;
        }
    }

    public void onMouseDown()
    {
        this.GetComponent<RectTransform>().sizeDelta = this.originalSize;
    }

    public void onMouseClick()
    {
        this.GetComponent<RectTransform>().sizeDelta = this.GetComponent<RectTransform>().sizeDelta * 2;
    }
}
