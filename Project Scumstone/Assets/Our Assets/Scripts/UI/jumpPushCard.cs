﻿using UnityEngine;
using System.Collections;

public class jumpPushCard : newCard {

	// Use this for initialization
	public override void Start () {
        base.Start();
        base.whiteEffect = "jumpBlock";
        base.blackEffect = "pushBlock";
	}

    public override void activateBlack()
    {
        base.activateBlack();

        if (base.hit.transform.GetComponent<moveObject>() != null)
        {
            base.hit.transform.GetComponent<moveObject>().activated = true;
            base.checkDualActivation(base.hit, "camera1");
        }
    }

    public override void activateWhite()
    {
        base.activateWhite();
        if (base.hit.transform.GetComponent<jumpObject>() != null)
        {
            Debug.Log("ACTIVATED JUMP BLOCK");
            base.hit.transform.GetComponent<jumpObject>().activated = true;
            base.checkDualActivation(base.hit, "camera2");
        }
    }
}
