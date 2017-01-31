using UnityEngine;
using System.Collections;

public class jumpPushCard : newCard {

	// Use this for initialization
	public override void Start () {
        base.Start();
        base.whiteEffect = "pullObject";
        base.blackEffect = "moveObject";
	}

    public override void activateBlack()
    {
        base.activateBlack();

        if (base.hit.transform.GetComponent<moveObject>() != null)
        {
            base.hit.transform.GetComponent<moveObject>().activated = true;
            base.checkDualActivation(base.hit);
        }
    }

    public override void activateWhite()
    {

     //JAN 26 MADE CHANGES TO THIS TO ALLOW IT TO PUSH RATHER THAN PULL
        base.activateWhite();
        if (base.hit.transform.GetComponent<pullObject>() != null)
        {
            //Debug.Log("ACTIVATED JUMP BLOCK");
            base.hit.transform.GetComponent<pullObject>().activated = !base.hit.transform.GetComponent<pullObject>().activated;
            base.checkDualActivation(base.hit);
        }
    }
}
