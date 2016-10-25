using UnityEngine;
using System.Collections;

public class card : MonoBehaviour {
    public GameObject camera1;
    public GameObject camera2;
    public bool beingDragged = false;
    //public bool clicked = false; // i added this to test something

    private float offsetX;
    private float offsetY;
    private Vector3 origin;
    private Vector2 originalSize;

    public virtual void Awake()
    {
        this.camera1 = GameObject.Find("Black Camera");
        this.camera2 = GameObject.Find("White Camera");
    }

	// Use this for initialization
	public virtual void Start () {
        this.origin = this.transform.position;
        this.originalSize = this.GetComponent<RectTransform>().sizeDelta; 
	}
	
	// Update is called once per frame
	public virtual void Update () {
	
	}

    public virtual void beginDrag()
    {
        offsetX = this.transform.position.x - Input.mousePosition.x;
        offsetY = this.transform.position.y - Input.mousePosition.y;
        this.beingDragged = true;
    }

    public virtual void onDrag()
    {
        this.transform.position = new Vector3(Input.mousePosition.x + offsetX, Input.mousePosition.y + offsetY);
    }

    public virtual void endDrag()
    {
        this.transform.position = origin;
        this.GetComponent<RectTransform>().sizeDelta = this.originalSize;
        this.beingDragged = false;
    }

    public virtual void onMouseEnter()
    {
        if (!this.beingDragged)
        {
            this.GetComponent<RectTransform>().sizeDelta = this.originalSize * 2;
        }
    }

    public virtual void onMouseExit()
    {
        if (!this.beingDragged)
        {
            this.GetComponent<RectTransform>().sizeDelta = this.originalSize;
        }
    }

    public virtual void onMouseDown()
    {
        this.GetComponent<RectTransform>().sizeDelta = this.originalSize;
        particleActivate();
    }

    public virtual void onMouseUp()
    {
        this.GetComponent<RectTransform>().sizeDelta = this.originalSize * 2;
        particleDeactivate();
    }

    public virtual RaycastHit2D checkHit(GameObject camera)
    {
        return Physics2D.Raycast(new Vector2(camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition).origin.x, camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition).origin.y), new Vector2(camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition).direction.x, camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition).direction.y));
    }

    public virtual void particleActivate()
    {

    }

    public virtual void particleDeactivate()
    {

    }

    public virtual void checkDualActivation(RaycastHit2D hit, string camera)
    {
        if (!hit.transform.GetComponent<activateObject>().dualActivation)
        {
            hit.transform.GetComponent<activateObject>().activated1 = true;
        }

        else
        {
            if (!hit.transform.GetComponent<activateObject>().activated1)
            {
                hit.transform.GetComponent<activateObject>().activated1 = true;
            }

            else
            {
                if ((camera == "camera1" && !hit.transform.GetComponent<activateObject>().camera1) || camera == "camera2" && !hit.transform.GetComponent<activateObject>().camera2)
                {
                    hit.transform.GetComponent<activateObject>().activated2 = true;
                }
            }

            if (camera == "camera1")
            {
                hit.transform.GetComponent<activateObject>().camera1 = true;
            }

            else if (camera == "camera2")
            {
                hit.transform.GetComponent<activateObject>().camera2 = true;
            }
        }
    }
}
