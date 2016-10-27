using UnityEngine;
using System.Collections;

public class newCard : MonoBehaviour {
    public GameObject camera1;
    public GameObject camera2;
    public bool isClicked = false;

	// Use this for initialization

    public virtual void Awake()
    {
        this.camera1 = GameObject.Find("Black Camera");
        this.camera2 = GameObject.Find("White Camera");
    }

    public virtual void onPointerEnter()
    {

    }

    public virtual void onPointerExit()
    {

    }

    public virtual void onClick()
    {

    }


    public virtual RaycastHit2D checkClick(GameObject camera)
    {
        return Physics2D.Raycast(new Vector2(camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition).origin.x, camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition).origin.y), new Vector2(camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition).direction.x, camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition).direction.y));
    }

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
