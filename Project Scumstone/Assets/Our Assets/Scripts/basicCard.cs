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
            }

        }

        else
        {
            hit = checkHit(camera2);
            if (hit)
            {
                if (hit.transform.CompareTag("jumpBlock"))
                {
                    Debug.Log("ACTIVATED JUMP BLOCK");
                    hit.transform.Find("jumpArea").GetComponent<jumpObject>().activated = true;
                }

                else if (hit.transform.FindChild("jumpArea"))
                {
                    Debug.Log("ACTIVATED JUMP BLOCK");
                    hit.transform.Find("jumpArea").GetComponent<jumpObject>().activated = true;
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
            if (pushBlocks[i].GetComponent<Light>() != null)
            {
                pushBlocks[i].GetComponent<Light>().enabled = true;
                if (!pushBlocks[i].GetComponent<moveObject>().activated)
                {
                    pushBlocks[i].GetComponent<ParticleSystem>().Play();
                }
            }
        }

        for (int i = 0; i < jumpBlocks.Length; i++)
        {
            if (jumpBlocks[i].GetComponent<Light>() != null)
            {
                jumpBlocks[i].GetComponent<Light>().enabled = true;
                if (!jumpBlocks[i].transform.Find("jumpArea").GetComponent<jumpObject>().activated)
                {
                    jumpBlocks[i].GetComponent<ParticleSystem>().Play();
                }
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
            if (pushBlocks[i].GetComponent<Light>() != null)
            {
                if (!pushBlocks[i].GetComponent<moveObject>().activated)
                {
                    pushBlocks[i].GetComponent<Light>().enabled = false;
                }
                pushBlocks[i].GetComponent<ParticleSystem>().Stop();
            }
        }

        for (int i = 0; i < jumpBlocks.Length; i++)
        {
            if (jumpBlocks[i].GetComponent<Light>() != null)
            {
                if (!jumpBlocks[i].transform.Find("jumpArea").GetComponent<jumpObject>().activated)
                {
                    jumpBlocks[i].GetComponent<Light>().enabled = false;
                }
                jumpBlocks[i].GetComponent<ParticleSystem>().Stop();
            }
        }
    }
}
