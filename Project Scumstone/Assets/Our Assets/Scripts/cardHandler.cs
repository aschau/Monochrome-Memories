using UnityEngine;
using System.Collections;

public class cardHandler : MonoBehaviour {
    public Camera camera1;
    public Camera camera2;
    
    private float offsetX;
    private float offsetY;
    private Vector3 origin;
    private Vector2 originalSize;
    public bool beingDragged = false;

    private RaycastHit2D hit;

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

    private RaycastHit2D checkHit(Camera camera)
    {
        return Physics2D.Raycast(new Vector2(camera.ScreenPointToRay(Input.mousePosition).origin.x, camera.ScreenPointToRay(Input.mousePosition).origin.y), new Vector2(camera.ScreenPointToRay(Input.mousePosition).direction.x, camera.ScreenPointToRay(Input.mousePosition).direction.y));
    }

    public void endDrag()
    {        
        hit = checkHit(camera1);
        if (hit)
        {
            if (hit.transform.CompareTag("pushBlock"))
            {
                Debug.Log("ACTIVATED PUSH BLOCK");
                hit.transform.GetComponent<moveObject>().activated = true;
            }

        }

        else
        {
            hit = checkHit(camera2);
            if (hit)
            {
                if (hit.transform.CompareTag("jumpBlock"))
                {
                    Debug.Log("ACTIVATED JUMP BLOCK");
                    hit.transform.GetComponent<moveObject>().activated = true;
                }
            }
        }

        this.transform.position = origin;
        this.GetComponent<RectTransform>().sizeDelta = this.originalSize;
        this.beingDragged = false;
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
