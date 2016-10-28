using UnityEngine;
using System.Collections;

public class gravityCard2 : newCard {
    private RaycastHit2D hit;
    // Use this for initialization
    public override void Start()
    {
        base.Start();
        base.whiteEffect = "floatBlock";
        base.blackEffect = "fallBlock";
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
                        hit.transform.GetComponent<fallObject>().activated = true;
                        base.checkDualActivation(hit, "camera1");
                    }

                }

                else
                {
                    hit = checkHit(camera2);
                    if (hit)
                    {
                        if (hit.transform.CompareTag(base.whiteEffect))
                        {
                            hit.transform.GetComponent<floatObject>().activated = true;
                            base.checkDualActivation(hit, "camera1");
                        }
                    }
                }
            }
        }
    }
}
