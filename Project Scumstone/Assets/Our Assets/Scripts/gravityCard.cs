using UnityEngine;
using System.Collections;

public class gravityCard : card {
    private RaycastHit2D hit;

    public override void Start()
    {
        base.Start();
        base.whiteEffect = "floatBlock";
        base.blackEffect = "fallBlock";
    }
    public override void onMouseUp()
    {
        hit = checkHit(camera1);
        if (hit)
        {
            if (hit.transform.CompareTag("fallBlock"))
            {
                Debug.Log("ACTIVATED FALL BLOCK");
                hit.transform.GetComponent<fallObject>().activated = true;
                base.checkDualActivation(hit, "camera1");
            }

        }

        else
        {
            hit = checkHit(camera2);
            if (hit)
            {
                if (hit.transform.CompareTag("floatBlock"))
                {
                    Debug.Log("ACTIVATED Float BLOCK");
                    hit.transform.GetComponent<floatObject>().activated = true;
                    base.checkDualActivation(hit, "camera2");
                }

            }
        }

        base.onMouseUp();
    }
}
