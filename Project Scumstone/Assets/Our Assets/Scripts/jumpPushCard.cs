using UnityEngine;
using System.Collections;

public class jumpPushCard : newCard {
    private RaycastHit2D hit;
    //private GameObject topImage, bottomImage;
	// Use this for initialization
	public override void Start () {
        base.Start();
        base.whiteEffect = "jumpBlock";
        base.blackEffect = "pushBlock";
        //this.topImage = GameObject.Find("topImage");
        //this.bottomImage = GameObject.Find("bottomImage");
	}

    public override void Update()
    {
        base.Update();

        if (base.isClicked)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!GameObject.Find("topImage"))
                {
                    hit = checkHit(camera1);
                    if (hit)
                    {
                        if (hit.transform.CompareTag(base.blackEffect))
                        {
                            hit.transform.GetComponent<moveObject>().activated = true;
                            base.checkDualActivation(hit, "camera1");
                        }

                    }
                }


                else if (!GameObject.Find("bottomImage"))
                {
                    hit = checkHit(camera2);
                    if (hit)
                    {
                        if (hit.transform.GetComponent<jumpObject>() != null)
                        {
                            Debug.Log("ACTIVATED JUMP BLOCK");
                            hit.transform.GetComponent<jumpObject>().activated = true;
                            base.checkDualActivation(hit, "camera2");
                        }
                    }
                }
            }
        }
    }
}
