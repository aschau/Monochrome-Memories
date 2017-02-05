using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
public abstract class newCard : MonoBehaviour {
    public bool isClicked = false;
    public Vector3 newLocation, oldLocation;
    public Sprite currentImage, newImage;
    public AudioClip cardSound;
    public float volume;
    public AudioSource source;
    public bool isCollected = true;

    [HideInInspector]
    public string blackEffect, whiteEffect;
    [HideInInspector]
    public GameObject camera1, camera2;
    [HideInInspector]
    public RaycastHit2D hit;

    private GameObject[] cards;
    private activateObject[] allObjects;
    private List<activateObject> visibleObjects = new List<activateObject>();
    private int selectedIndex = 0, prevIndex = 0;
    public virtual void Awake()
    {
        this.camera1 = GameObject.Find("Black Camera");
        this.camera2 = GameObject.Find("White Camera");
        this.source = GameObject.Find("card effect").GetComponent<AudioSource>();
        this.cards = GameObject.FindGameObjectsWithTag("gameCards");
        this.allObjects = GameObject.FindObjectsOfType<activateObject>();

    }

    public virtual void Start()
    {
        newLocation = new Vector3(this.transform.position.x - 20, this.transform.position.y, this.transform.position.z);
        oldLocation = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
    }

    // Update is called once per frame
    public virtual void Update()
    {
        //foreach (activateObject obj in allObjects)
        //{
        //    if (obj.GetComponent<SpriteRenderer>().isVisible && obj.GetComponent(this.blackEffect))
        //    {
        //        this.visibleObjects.Add(obj);
        //    }
        //}
            
        //this.visibleObjects[this.selectedIndex].selected = true;
        //this.visibleObjects[this.selectedIndex].GetComponent<SpriteRenderer>().color = new Color(0f, 120f, 255f);
        if (this.isClicked)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (this.selectedIndex < this.visibleObjects.Count-1)
                {
                    this.prevIndex = this.selectedIndex;
                    this.selectedIndex++;
                }

                else
                {
                    this.prevIndex = this.selectedIndex;
                    this.selectedIndex = 0;
                }
                
                this.visibleObjects[this.prevIndex].selected = false;

                this.visibleObjects[this.selectedIndex].selected = true;
                this.visibleObjects[this.selectedIndex].GetComponent<SpriteRenderer>().color = new Color(0f, 120f, 255f);
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                this.visibleObjects[this.selectedIndex].GetComponent<baseObject>().activated = true;
                this.checkDualActivation(this.visibleObjects[this.selectedIndex].transform);
            }

            if (!EventSystem.current.IsPointerOverGameObject())
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
    }

    private void getVisibileObjects()
    {
        //this.visibleObjects[this.selectedIndex].selected = false;
        this.visibleObjects = new List<activateObject>();
        this.selectedIndex = 0;
        this.prevIndex = 0;
        foreach (activateObject obj in allObjects)
        {
            if (playerMovement.player == "Player")
            {
                if (obj.GetComponent<SpriteRenderer>().isVisible && obj.GetComponent(this.blackEffect))
                {
                    this.visibleObjects.Add(obj);
                }
            }

            else if (playerMovement.player == "Player 2")
            {
                if (obj.GetComponent<SpriteRenderer>().isVisible && obj.GetComponent(this.whiteEffect))
                {
                    this.visibleObjects.Add(obj);
                }
            }
        }

        if (this.visibleObjects.Count > 0)
        {
            this.visibleObjects[selectedIndex].selected = true;
            this.visibleObjects[this.selectedIndex].GetComponent<SpriteRenderer>().color = new Color(0f, 120f, 255f);
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
            getVisibileObjects();
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
                            ParticleSystem.MainModule m = allObjects[i].GetComponent<ParticleSystem>().main;
                            m.startColor = new ParticleSystem.MinMaxGradient(obj.particleColor, obj.particleColor);
                            break;
                        }
                    }

                    else
                    {
                        if (!(allObjects[i].activated1 && allObjects[i].activated2))
                        {
                            allObjects[i].GetComponent<ParticleSystem>().Play(false);
                            ParticleSystem.MainModule m = allObjects[i].GetComponent<ParticleSystem>().main;
                            m.startColor = new ParticleSystem.MinMaxGradient(obj.particleColor, obj.particleColor);
                            break;
                        }
                    }
                }
            }

        }
    }

    public virtual void particleDeactivate()
    {
        for (int i = 0; i < allObjects.Length; i++)
        {
            baseObject[] specificObjects = allObjects[i].GetComponents<baseObject>();

            foreach (baseObject obj in specificObjects)
            {
                if (obj.GetType().Name == this.blackEffect || obj.GetType().Name == this.whiteEffect)
                {

                    allObjects[i].GetComponent<ParticleSystem>().Stop(false);
                    break;
                }
            }
        }
    }

    public virtual RaycastHit2D checkHit(GameObject camera)
    {
        return Physics2D.Raycast(new Vector2(camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition).origin.x, camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition).origin.y), new Vector2(camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition).direction.x, camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition).direction.y));
    }

    public virtual void checkDualActivation(Transform hit, bool ignoreParticles = true)
    {
        if (!hit.transform.GetComponent<activateObject>().dualActivation)
        {
            hit.transform.GetComponent<activateObject>().activated1 = true;
            if (ignoreParticles)
            {
                hit.transform.GetComponent<ParticleSystem>().Stop();
            }
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
                    if (ignoreParticles)
                    {
                        hit.transform.GetComponent<ParticleSystem>().Stop();
                    }
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
