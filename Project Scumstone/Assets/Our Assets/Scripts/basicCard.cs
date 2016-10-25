using UnityEngine;
using System.Collections;

public class basicCard : card {
    private RaycastHit2D hit;

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

    public override void particleActivate()
    {
        base.particleActivate();
        GameObject[] pushBlocks = GameObject.FindGameObjectsWithTag("pushBlock");
        GameObject[] jumpBlocks = GameObject.FindGameObjectsWithTag("jumpBlock");
        for (int i = 0; i < pushBlocks.Length; i++)
        {
                if (!pushBlocks[i].GetComponent<moveObject>().activated)
                {
                    pushBlocks[i].GetComponent<ParticleSystem>().Play();
                }
        }

        for (int i = 0; i < jumpBlocks.Length; i++)
        {
            if (!jumpBlocks[i].transform.GetComponent<jumpObject>().activated)
            {
                jumpBlocks[i].GetComponent<ParticleSystem>().Play();
            }
        }
    }

    public override void particleDeactivate()
    {
        base.particleDeactivate();
        GameObject[] pushBlocks = GameObject.FindGameObjectsWithTag("pushBlock");
        GameObject[] jumpBlocks = GameObject.FindGameObjectsWithTag("jumpBlock");

        for (int i = 0; i < pushBlocks.Length; i++)
        {
                pushBlocks[i].GetComponent<ParticleSystem>().Stop();
        }

        for (int i = 0; i < jumpBlocks.Length; i++)
        {
            jumpBlocks[i].GetComponent<ParticleSystem>().Stop();
        }
    }
}
