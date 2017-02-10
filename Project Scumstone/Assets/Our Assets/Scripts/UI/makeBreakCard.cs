using UnityEngine;
using System.Collections;

public class makeBreakCard : newCard {
    public override void Start()
    {
        base.Start();
        base.whiteEffect = "makeBlock";
        base.blackEffect = "breakBlock";
    }


    public override void activateBlack()
    {
        base.activateBlack();

        if (base.hit.transform.GetComponent<breakObject>() != null)
        {
            base.hit.transform.GetComponent<breakObject>().activated = true;
            base.checkDualActivation(base.hit.transform);
        }
    }

    public override void activateWhite()
    {
        base.activateWhite();

        if (base.hit.transform.GetComponent<makeObject>() != null)
        {
            base.hit.transform.GetComponent<makeObject>().activated = true;
            base.checkDualActivation(base.hit.transform);
        }
    }
}
