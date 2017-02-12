using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System.Linq;
public abstract class newCard : MonoBehaviour {
    public bool isClicked = false;
    //public Vector3 newLocation, oldLocation;
    public Sprite currentImage, newImage;
    public AudioClip cardSound;
    public float volume;
    public AudioSource source;
    public bool isCollected = true;
    public static bool isTop = true;

    [HideInInspector]
    public string blackEffect, whiteEffect;
    [HideInInspector]
    public GameObject camera1, camera2;
    [HideInInspector]
    public RaycastHit2D hit;

    private GameObject player1, player2;
    private GameObject[] cards;
    private activateObject[] allObjects;
    private List<activateObject> visibleObjects = new List<activateObject>();
    private int selectedIndex = 0, prevIndex = 0;
    private Animator anim;
    public virtual void Awake()
    {
        this.camera1 = GameObject.Find("Black Camera");
        this.camera2 = GameObject.Find("White Camera");
        this.source = GameObject.Find("card effect").GetComponent<AudioSource>();
        this.cards = GameObject.FindGameObjectsWithTag("gameCards");
        this.allObjects = GameObject.FindObjectsOfType<activateObject>();
        this.anim = this.GetComponent<Animator>();
        this.player1 = GameObject.Find("Player");
        this.player2 = GameObject.Find("Player 2");

    }

    public virtual void Start()
    {
        isTop = true;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)))
        {
            if (this.name == "jumpPushCard1")
            {
                isTop = !isTop;
            }
        }

        if (this.isClicked)
        {
            this.getVisibileObjects();

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

                this.toggleObject(this.prevIndex);

                this.toggleObject(this.selectedIndex);
            }

            if (Input.GetKeyDown(KeyCode.Return) && this.visibleObjects.Count > 0)
            {
                if (isTop)
                {
                    if (this.visibleObjects[this.selectedIndex].GetComponent(this.blackEffect))
                    {
                        (this.visibleObjects[this.selectedIndex].GetComponent(this.blackEffect) as baseObject).activated = !(this.visibleObjects[this.selectedIndex].GetComponent(this.blackEffect) as baseObject).activated;
                        Debug.Log("Activated: " + this.visibleObjects[this.selectedIndex].GetComponent(this.blackEffect).gameObject.name);
                    }
                }

                else
                {
                    if (this.visibleObjects[this.selectedIndex].GetComponent(this.whiteEffect))
                    {
                        (this.visibleObjects[this.selectedIndex].GetComponent(this.whiteEffect) as baseObject).activated = !(this.visibleObjects[this.selectedIndex].GetComponent(this.whiteEffect) as baseObject).activated;
                        Debug.Log("Activated: " + this.visibleObjects[this.selectedIndex].GetComponent(this.whiteEffect).gameObject.name);
                    }
                }
                this.checkDualActivation(this.visibleObjects[this.selectedIndex].transform);
            }

            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (!GameObject.Find("topImage"))
                    {
                        hit = checkHit(camera1, Input.mousePosition);
                        if (hit)
                        {
                            this.activateBlack();
                        }
                    }


                    else if (!GameObject.Find("bottomImage"))
                    {
                        hit = checkHit(camera2, Input.mousePosition);
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
       List<activateObject> newList = new List<activateObject>();

        foreach (activateObject obj in allObjects)
        {
            if (isTop)
            {
                if (obj.GetComponent<SpriteRenderer>().isVisible && obj.GetComponent(this.blackEffect) && this.checkHitKey(this.camera1, obj.transform.position))
                {
                    newList.Add(obj);
                }
            }

            else
            {
                if (obj.GetComponent<SpriteRenderer>().isVisible && obj.GetComponent(this.whiteEffect) && this.checkHitKey(this.camera2, obj.transform.position))
                {
                    newList.Add(obj);
                }
            }

        }

        if (isTop)
        {
            newList = newList.OrderBy(x => Vector2.Distance(this.player1.transform.position, x.transform.position)).ToList();
        }

        else
        {
            newList = newList.OrderBy(x => Vector2.Distance(this.player2.transform.position, x.transform.position)).ToList();
        }

        if (this.visibleObjects.Count > 0)
        {
            bool selectedVisible = false;
            activateObject prevObj = this.visibleObjects[this.selectedIndex];
            for (int i = 0; i < newList.Count; i++)
            {

                if (newList[i].gameObject.GetInstanceID() == this.visibleObjects[this.selectedIndex].gameObject.GetInstanceID())
                {
                    this.selectedIndex = i;
                    if (this.selectedIndex == 0)
                    {
                        this.prevIndex = newList.Count - 1;
                    }
                    else
                    {
                        this.prevIndex = this.selectedIndex - 1;
                    }
                    selectedVisible = true;
                    break;
                }
            }

            if (!selectedVisible)
            {
                prevObj.toggleSelection();
                if (newList.Count > 0)
                    newList[0].toggleSelection();
            }

            else if (!newList[0].selected)
            {
                newList[0].toggleSelection();
            }
        }

        else
        {
            if (newList.Count > 0)
                newList[0].toggleSelection();
        }


        this.visibleObjects = newList;

        if (this.visibleObjects.Count == 0 || this.selectedIndex > this.visibleObjects.Count - 1)
        {
            this.selectedIndex = 0;
            this.prevIndex = 0;
        }
    }

    private void toggleObject(int index)
    {
        if (this.visibleObjects.Count > 0)
        {
            this.visibleObjects[index].toggleSelection();
            Debug.Log("Toggled: " + this.visibleObjects[index].name);
        }
    }

    public virtual void onPointerEnter()
    {
        this.anim.SetBool("onHover", true);
        particleActivate();
        source.PlayOneShot(cardSound, volume);
    }

    public virtual void onPointerExit()
    {
        this.anim.SetBool("onHover", false);

        if (this.isClicked == false)
        {
            particleDeactivate();
        }

    }

    public virtual void onClick()
    {
        this.isClicked = !(this.isClicked);
        if (this.isClicked)
        {
            this.anim.SetBool("isSelected", true);
            this.prevIndex = 0;
            this.selectedIndex = 0;
            getVisibileObjects();
            //this.toggleObject(this.selectedIndex);
            foreach (GameObject card in cards)
            {
                if (card.name != this.name)
                {
                    card.GetComponent<newCard>().turnOff();
                }
            }

            particleActivate();
        }

        else
        {
            this.anim.SetBool("isSelected", false);
            this.toggleObject(this.selectedIndex);
            this.selectedIndex = 0;
            this.prevIndex = 0;
        }

    }
    public virtual void turnOff()
    {
        this.isClicked = false;
        this.anim.SetBool("isSelected", false);
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

    public virtual bool checkHitKey(GameObject camera, Vector3 position)
    {
        Vector3 cameraRay = camera.GetComponent<Camera>().WorldToViewportPoint(position);
        //Debug.DrawLine(new Vector2(cameraRay.origin.x, cameraRay.origin.y), new Vector2(cameraRay.direction.x, cameraRay.direction.y));
        return cameraRay.x <= 1 && cameraRay.x >= 0 && cameraRay.y <= 1 && cameraRay.y >= 0;
    }

    public virtual RaycastHit2D checkHit(GameObject camera, Vector2 position)
    {
        Ray cameraRay = camera.GetComponent<Camera>().ScreenPointToRay(position);
        return Physics2D.Raycast(new Vector2(cameraRay.origin.x, cameraRay.origin.y), new Vector2(cameraRay.direction.x, cameraRay.direction.y));
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
