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

    public override void Update()
    {
        base.Update();

        if (base.isClicked)
        {
            if (Input.GetMouseButtonDown(0))
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

                else
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
