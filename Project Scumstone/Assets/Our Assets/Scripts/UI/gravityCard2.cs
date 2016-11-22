using UnityEngine;
using System.Collections;

public class gravityCard2 : newCard {
    //public bool search = false;
    // Use this for initialization
    public override void Start()
    {
        base.Start();
        base.whiteEffect = "fallBlock";
        base.blackEffect = "floatBlock";
    }

    public override void activateBlack()
    {
        base.activateBlack();

        if (base.hit.transform.GetComponent<floatObject>() != null)
        {
            base.hit.transform.GetComponent<floatObject>().activated = true;
            base.checkDualActivation(base.hit, "camera1");
        }
    }

    public override void activateWhite()
    {
        base.activateWhite();

        if (base.hit.transform.GetComponent<fallObject>() != null)
        {
            base.hit.transform.GetComponent<fallObject>().activated = true;
            base.checkDualActivation(base.hit, "camera2");
        }
    }
}
