using UnityEngine;
using System.Collections;

public class jumpPushCard : newCard {
    private RaycastHit2D hit;
	// Use this for initialization
	public override void Start () {
        base.Start();
        base.whiteEffect = "jumpBlock";
        base.blackEffect = "pushBlock";
	}
	
	// Update is called once per frame
	public override void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("This can check hits");
            /*hit = checkClick(camera1);
            if (hit)
            {
                if (hit.transform.CompareTag(this.whiteEffect))
                {
                    Debug.Log("ACTIVATED JUMP BLOCK");
                    hit.transform.GetComponent<jumpObject>().activated = true;
                    //base.checkDualActivation(hit, "camera1");
                }

            }

            else
            {
                hit = checkClick(camera2);
                if (hit)
                {
                    if (hit.transform.CompareTag(this.blackEffect))
                    {
                        Debug.Log("ACTIVATED push BLOCK");
                        hit.transform.GetComponent<moveObject>().activated = true;
                        //base.checkDualActivation(hit, "camera2");
                    }

                }
            }*/
        }
	
	}
}
