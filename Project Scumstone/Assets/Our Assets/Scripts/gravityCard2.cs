using UnityEngine;
using System.Collections;

public class gravityCard2 : newCard {
    private RaycastHit2D hit;
    public bool search = false;
    // Use this for initialization
    public override void Start()
    {
        base.Start();
        base.whiteEffect = "fallBlock";
        base.blackEffect = "floatBlock";
    }

    public override void Update()
    {
        GameObject[] cards = GameObject.FindGameObjectsWithTag("gameCards");
        foreach (GameObject card in cards)
        {
            if (card.GetComponent<onHover>().hovering == true)
            {
                search = false;
            }
        }

        base.Update();

        if (base.isClicked)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (search == true)
                {
                    if (!GameObject.Find("topImage"))
                    {
                        hit = checkHit(camera1);
                        if (hit)
                        {
                            if (hit.transform.GetComponent<floatObject>() != null)
                            {
                                hit.transform.GetComponent<floatObject>().activated = true;
                                base.checkDualActivation(hit, "camera1");
                            }

                        }
                    }

                    else if (!GameObject.Find("bottomImage"))
                    {
                        hit = checkHit(camera2);
                        if (hit)
                        {
                            if (hit.transform.GetComponent<fallObject>() != null)
                            {
                                hit.transform.GetComponent<fallObject>().activated = true;
                                base.checkDualActivation(hit, "camera2");
                            }
                        }
                    }
                }
            }
        }
        search = true;
    }
}
