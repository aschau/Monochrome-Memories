using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class newCard : MonoBehaviour {
    public bool isClicked = false;
    public Sprite currentImage;
    public Sprite newImage;
    public Vector3 newLocation;
    public Vector3 oldLocation;
    public AudioClip cardSound;
    public float volume;
    AudioSource source;

    [HideInInspector]
    public string blackEffect, whiteEffect;
    [HideInInspector]
    public GameObject camera1, camera2;

    public virtual void Awake()
    {
        this.camera1 = GameObject.Find("Black Camera");
        this.camera2 = GameObject.Find("White Camera");
    }

    public virtual void Start()
    {
        newLocation = new Vector3(this.transform.position.x - 20, this.transform.position.y, this.transform.position.z);
        oldLocation = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public virtual void Update()
    {

    }

    public virtual void onPointerEnter()
    {
        this.GetComponent<Image>().sprite = newImage;
        this.transform.position = newLocation;
        particleActivate();
        source.PlayOneShot(cardSound, volume);
        //yield return new WaitForSeconds(0.2f);
    }

    public virtual void onPointerExit()
    {
        if (this.isClicked == false)
        {
            this.GetComponent<Image>().sprite = currentImage;
            this.transform.position = oldLocation;
            particleDeactivate();
        }
        
    }

    public virtual void onClick()
    {
        this.isClicked = !(this.isClicked);

    }


    public virtual RaycastHit2D checkClick(GameObject camera)
    {
        return Physics2D.Raycast(new Vector2(camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition).origin.x, camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition).origin.y), new Vector2(camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition).direction.x, camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition).direction.y));
    }

    public virtual void particleActivate()
    {
        activateObject[] allObjects = GameObject.FindObjectsOfType<activateObject>();

        for (int i = 0; i < allObjects.Length; i++)
        {
            if (allObjects[i].CompareTag(this.blackEffect) || allObjects[i].CompareTag(this.whiteEffect))
            {

                if (!allObjects[i].dualActivation)
                {
                    if (!allObjects[i].activated1)
                    {
                        allObjects[i].GetComponent<ParticleSystem>().Play();
                    }
                }

                else
                {
                    if (!(allObjects[i].activated1 && allObjects[i].activated2))
                    {
                        allObjects[i].GetComponent<ParticleSystem>().Play();
                    }
                }
            }
        }
    }

    public virtual void particleDeactivate()
    {
        activateObject[] allObjects = GameObject.FindObjectsOfType<activateObject>();

        for (int i = 0; i < allObjects.Length; i++)
        {
            if (allObjects[i].CompareTag(this.blackEffect) || allObjects[i].CompareTag(this.whiteEffect))
            {

                allObjects[i].GetComponent<ParticleSystem>().Stop();
            }
        }
    }

    public virtual RaycastHit2D checkHit(GameObject camera)
    {
        return Physics2D.Raycast(new Vector2(camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition).origin.x, camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition).origin.y), new Vector2(camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition).direction.x, camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition).direction.y));
    }

    public virtual void checkDualActivation(RaycastHit2D hit, string camera)
    {
        if (!hit.transform.GetComponent<activateObject>().dualActivation)
        {
            hit.transform.GetComponent<activateObject>().activated1 = true;
            hit.transform.GetComponent<ParticleSystem>().Stop();
        }

        else
        {
            if (!hit.transform.GetComponent<activateObject>().activated1)
            {
                hit.transform.GetComponent<activateObject>().activated1 = true;
            }

            else
            {
                if ((camera == "camera1" && !hit.transform.GetComponent<activateObject>().camera1) || camera == "camera2" && !hit.transform.GetComponent<activateObject>().camera2)
                {
                    hit.transform.GetComponent<activateObject>().activated2 = true;
                    hit.transform.GetComponent<ParticleSystem>().Stop();
                }
            }

            if (camera == "camera1")
            {
                hit.transform.GetComponent<activateObject>().camera1 = true;
            }

            else if (camera == "camera2")
            {
                hit.transform.GetComponent<activateObject>().camera2 = true;
            }
        }
    }

}
