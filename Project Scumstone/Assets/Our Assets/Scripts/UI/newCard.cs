using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
public abstract class newCard : MonoBehaviour {
    public bool isClicked = false;
    public Vector3 newLocation, oldLocation;
    public Sprite currentImage, newImage;
    public AudioClip cardSound;
    public float volume;
    AudioSource source;

    [HideInInspector]
    public string blackEffect, whiteEffect;
    [HideInInspector]
    public GameObject camera1, camera2;
    [HideInInspector]
    public RaycastHit2D hit;

    private GameObject[] cards;

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
        this.cards = GameObject.FindGameObjectsWithTag("gameCards");
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (this.isClicked && !EventSystem.current.IsPointerOverGameObject())
        {

            if (Input.GetMouseButtonDown(0))
            {
                if (!GameObject.Find("topImage"))
                {
                    hit = checkHit(camera1);
                    if (hit)
                    {
                        this.activateBlack();
                    }
                }


                else if (!GameObject.Find("bottomImage"))
                {
                    hit = checkHit(camera2);
                    if (hit)
                    {
                        this.activateWhite();
                    }
                }
            }
        }
    }

    public virtual void onPointerEnter()
    {
        this.GetComponent<Image>().sprite = newImage;
        this.transform.position = newLocation;
        particleActivate();
        source.PlayOneShot(cardSound, volume);
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
        if (this.isClicked == true)
        {
            foreach (GameObject card in cards)
            {
                if (card.name != this.name)
                {
                    card.GetComponent<newCard>().turnOff();
                }
            }

            particleActivate();
        }

    }
    public virtual void turnOff()
    {
        this.isClicked = false;
        this.GetComponent<Image>().sprite = currentImage;
        this.transform.position = oldLocation;
        this.particleDeactivate();
    }

    public virtual void particleActivate()
    {
        activateObject[] allObjects = GameObject.FindObjectsOfType<activateObject>();

        for (int i = 0; i < allObjects.Length; i++)
        {
            baseObject[] specificObjects = allObjects[i].GetComponents<baseObject>();

            foreach (baseObject obj in specificObjects)
            {
                if (obj.GetType().Name == this.blackEffect || obj.GetType().Name == this.whiteEffect)
                {

                    if (!allObjects[i].dualActivation)
                    {
                        if (!allObjects[i].activated1)
                        {
                            allObjects[i].GetComponent<ParticleSystem>().Play(false);
                            allObjects[i].GetComponent<ParticleSystem>().startColor = obj.particleColor;
                            break;
                        }
                    }

                    else
                    {
                        if (!(allObjects[i].activated1 && allObjects[i].activated2))
                        {
                            allObjects[i].GetComponent<ParticleSystem>().Play(false);
                            allObjects[i].GetComponent<ParticleSystem>().startColor = obj.particleColor;
                            break;
                        }
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
            baseObject[] specificObjects = allObjects[i].GetComponents<baseObject>();

            foreach (baseObject obj in specificObjects)
            {
                if (obj.GetType().Name == this.blackEffect || obj.GetType().Name == this.whiteEffect)
                {

                    allObjects[i].GetComponent<ParticleSystem>().Stop(false);
                }
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
                if (hit.transform.GetComponent<activateObject>().activatedScript1 != hit.transform.GetComponent<activateObject>().activatedScript2)
                {
                    hit.transform.GetComponent<activateObject>().activated2 = true;
                    hit.transform.GetComponent<ParticleSystem>().Stop();
                }
            }
        }
    }

    public virtual void activateBlack()
    {
        this.checkActivatedType(this.blackEffect);
    }

    public virtual void activateWhite()
    {
        this.checkActivatedType(this.whiteEffect);
    }

    public virtual void checkActivatedType(string effect)
    {
        if (this.hit.transform.GetComponent<activateObject>())
        {
            if (!this.hit.transform.GetComponent<activateObject>().dualActivation)
            {
                this.hit.transform.GetComponent<activateObject>().activatedScript1 = effect;
            }

            else
            {
                if (!this.hit.transform.GetComponent<activateObject>().activated1)
                {
                    this.hit.transform.GetComponent<activateObject>().activatedScript1 = effect;
                }

                else if (!this.hit.transform.GetComponent<activateObject>().activated2)
                {
                    this.hit.transform.GetComponent<activateObject>().activatedScript2 = effect;
                }
            }
        }

    }
}
