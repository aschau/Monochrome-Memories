using UnityEngine;
using System.Collections;

public class clickObjects : MonoBehaviour {
    public GameObject cardClicked;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (cardClicked.GetComponent<newCard>().isClicked == true)
            {
                checkDualActivation(checkClick());
            }
        }
	}

    public virtual void onClick()
    {
        Debug.Log("A click is registered.");
        checkDualActivation(checkClick());
    }
    public virtual RaycastHit2D checkClick()
    {
        return Physics2D.Raycast(new Vector2(this.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition).origin.x, this.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition).origin.y), new Vector2(this.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition).direction.x, this.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition).direction.y));
    }

    public virtual void checkDualActivation(RaycastHit2D hit)
    {
        if (hit)
        {
            if (hit.transform.GetComponent<activateObject>().dualActivation == false)
            {
                if (this.name == "Black Camera")
                {
                    Debug.Log("PUSH BLOCK ACTIVATED.");
                    hit.transform.GetComponent<activateObject>().activated1 = true; //basically if it  is not dual than it is activated
                    if (hit.transform.tag == "pushBlock")
                    {
                        hit.transform.GetComponent<moveObject>().activated = true;
                    }
                }
                else
                {
                    Debug.Log("jump block activated.");
                    hit.transform.GetComponent<activateObject>().activated1 = true; //basically if it  is not dual than it is activated
                    if (hit.transform.tag == "jumpBlock")
                    {
                        hit.transform.GetComponent<jumpObject>().activated = true;
                    }
                }


            }
            else
            {
                if (this.name == "White Camera")
                {
                    Debug.Log("Jump activated2.");
                    hit.transform.GetComponent<activateObject>().activated2 = true;
                    if (hit.transform.tag == "jumpBlock" || hit.transform.tag == "pushBlock")
                    {
                        hit.transform.GetComponent<jumpObject>().activated = true;
                    }
                }
                else
                {
                    Debug.Log("Push activated2.");
                    hit.transform.GetComponent<activateObject>().activated1 = true;
                    if (hit.transform.tag == "pushBlock" || hit.transform.tag == "jumpBlock")
                    {
                        hit.transform.GetComponent<moveObject>().activated = true;
                    }
                }
            }
        }

    }

}
