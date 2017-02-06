using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gravityCard2 : newCard {
    //public bool search = false;
    // Use this for initialization
    public override void Start()
    {
        base.Start();
        base.whiteEffect = "fallObject";
        base.blackEffect = "floatObject";
    }

    //public override void onPointerEnter()
    //{
    //    this.GetComponent<Image>().sprite = newImage;
    //    //this.transform.position = newLocation;
    //    base.particleActivate();
    //    base.source.PlayOneShot(cardSound, volume);        
    //}

    public override void activateBlack()
    {
        base.activateBlack();

        if (base.hit.transform.GetComponent<floatObject>() != null)
        {
            base.hit.transform.GetComponent<floatObject>().activated = !base.hit.transform.GetComponent<floatObject>().activated;
            base.checkDualActivation(base.hit.transform, true);
        }
    }

    public override void activateWhite()
    {
        base.activateWhite();

        if (base.hit.transform.GetComponent<fallObject>() != null)
        {
            base.hit.transform.GetComponent<fallObject>().activated = !base.hit.transform.GetComponent<fallObject>().activated;
            base.checkDualActivation(base.hit.transform, true);
        }
    }
}
