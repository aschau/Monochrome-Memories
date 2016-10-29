using UnityEngine;
using System.Collections;

public class basicCard : card {
    private RaycastHit2D hit;

    public override void Start()
    {
        base.Start();
        base.blackEffect = "pushBlock";
        base.whiteEffect = "jumpBlock";
    }

    public override void onMouseUp()
    {
        hit = checkHit(camera1);
        if (hit)
        {
            if (hit.transform.CompareTag("pushBlock"))
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

        base.onMouseUp();
    }
}
