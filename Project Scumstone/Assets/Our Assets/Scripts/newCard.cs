using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class newCard : MonoBehaviour {
    public GameObject camera1;
    public GameObject camera2;
    public Sprite currentImage;
    public bool isClicked = false;
    public Sprite newImage;
    public string blackEffect, whiteEffect;

	// Use this for initialization

    public virtual void Awake()
    {
        this.camera1 = GameObject.Find("Black Camera");
        this.camera2 = GameObject.Find("White Camera");
    }

    public virtual void onPointerEnter()
    {
        this.GetComponent<Image>().sprite = newImage;
        particleActivate();
    }

    public virtual void onPointerExit()
    {
        if (this.isClicked == false)
        {
            this.GetComponent<Image>().sprite = currentImage;
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

	public virtual void Start () {
	
	}
	
	// Update is called once per frame
	public virtual void Update () {
	
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


}
