using UnityEngine;
using System.Collections;

public class gravityCard : card {
    private RaycastHit2D hit;

    public override void onMouseUp()
    {
        hit = checkHit(camera1);
        if (hit)
        {
            if (hit.transform.CompareTag("fallBlock"))
            {
                Debug.Log("ACTIVATED FALL BLOCK");
                hit.transform.GetComponent<fallObject>().activated = true;
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
                }

            }
        }

        base.onMouseUp();
    }

    public override void particleActivate()
    {
        base.particleActivate();
        GameObject[] fallBlocks = GameObject.FindGameObjectsWithTag("fallBlock");
        GameObject[] floatBlocks = GameObject.FindGameObjectsWithTag("floatBlock");
        for (int i = 0; i < fallBlocks.Length; i++)
        {
            if (fallBlocks[i].GetComponent<Light>() != null)
            {
                fallBlocks[i].GetComponent<Light>().enabled = true;
                if (!fallBlocks[i].GetComponent<fallObject>().activated)
                {
                    fallBlocks[i].GetComponent<ParticleSystem>().Play();
                }
            }
        }

        for (int i = 0; i < floatBlocks.Length; i++)
        {
            if (floatBlocks[i].GetComponent<Light>() != null)
            {
                floatBlocks[i].GetComponent<Light>().enabled = true;
                if (!floatBlocks[i].GetComponent<floatObject>().activated)
                {
                    floatBlocks[i].GetComponent<ParticleSystem>().Play();
                }
            }
        }
    }

    public override void particleDeactivate()
    {
        base.particleDeactivate();
        GameObject[] fallBlocks = GameObject.FindGameObjectsWithTag("fallBlock");
        GameObject[] floatBlocks = GameObject.FindGameObjectsWithTag("floatBlock");

        for (int i = 0; i < fallBlocks.Length; i++)
        {
            if (fallBlocks[i].GetComponent<Light>() != null)
            {
                if (!fallBlocks[i].GetComponent<fallObject>().activated)
                {
                    fallBlocks[i].GetComponent<Light>().enabled = false;
                }
                fallBlocks[i].GetComponent<ParticleSystem>().Stop();
            }
        }

        for (int i = 0; i < floatBlocks.Length; i++)
        {
            if (floatBlocks[i].GetComponent<Light>() != null)
            {
                if (!floatBlocks[i].transform.GetComponent<floatObject>().activated)
                {
                    floatBlocks[i].GetComponent<Light>().enabled = false;
                }
                floatBlocks[i].GetComponent<ParticleSystem>().Stop();
            }
        }
    }
}
