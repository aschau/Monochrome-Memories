﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Transport : MonoBehaviour
{
    public float speed = 10f, delay = 1.2f;
    public Transform newPlace;
    private Camera camera1, camera2;
    private bool activated = false;
    private Behaviour halo;
    private Image topImage, bottomImage;
    private playerController playerControl;

    // Use this for initialization
    void Awake()
    {
        this.camera1 = GameObject.Find("Black Camera").GetComponent<Camera>();
        this.camera2 = GameObject.Find("White Camera").GetComponent<Camera>();
        this.newPlace = this.transform.Find("newPlace");
        this.delay = 3f;
        this.halo = (Behaviour)this.transform.GetChild(0).GetComponent("Halo");
        this.topImage = GameObject.Find("topImage").GetComponent<Image>();
        this.bottomImage = GameObject.Find("bottomImage").GetComponent<Image>();
        this.playerControl = GameObject.Find("playerControl").GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (camera1.GetComponent<playerCamera>().panning && this.activated)
        {
            Debug.Log(newPlace.transform.position.x);
            this.topImage.enabled = false;
            this.camera1.transform.position = Vector3.MoveTowards(this.camera1.transform.position, new Vector3(newPlace.transform.position.x, this.camera1.transform.position.y, this.camera1.transform.position.z), this.speed * Time.deltaTime);
            if (checkPanningFinish(camera1))
            {
                StartCoroutine(panningOff(this.camera1, this.delay));
            }
        }

        else if (camera2.GetComponent<playerCamera>().panning && this.activated)
        {
            this.bottomImage.enabled = false;
            this.camera2.transform.position = Vector3.MoveTowards(this.camera2.transform.position, new Vector3(newPlace.transform.position.x, this.camera2.transform.position.y, this.camera2.transform.position.z), this.speed * Time.deltaTime);
            if (checkPanningFinish(camera2))
            {
                StartCoroutine(panningOff(this.camera2, this.delay));
            }
        }
    }

    IEnumerator panningOff(Camera camera, float delay)
    {
        this.halo.enabled = !this.halo.enabled;
        yield return new WaitForSeconds(delay);
        camera.GetComponent<playerCamera>().panning = false;
        this.activated = false;
        this.halo.enabled = false;
        if (playerMovement.player == "Player")
        {
            this.bottomImage.enabled = true;
        }
        else
        {
            this.topImage.enabled = true;
        }
        this.playerControl.gameObject.SetActive(true);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        transportObject(other.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<activateObject>())
        {
            if (other.GetComponent<activateObject>().dualActivation){
                if (other.GetComponent<activateObject>().activated1)
                {
                    other.GetComponent<activateObject>().activated1 = false;
                }
                else if (other.GetComponent<activateObject>().activated2)
                {
                    other.GetComponent<activateObject>().activated2 = false;
                }
            }
            
        }
        transportObject(other.gameObject);
    }

    void transportObject(GameObject other)
    {
        if (other.transform.FindChild("Player"))
        {
            other.transform.FindChild("Player").parent = null;
        }

        else if (other.transform.FindChild("Player 2"))
        {
            other.transform.FindChild("Player 2").parent = null;
        }

        if (other.transform.GetComponent<boxTriggers>() || other.transform.GetComponent<baseObject>())
        {
            this.activated = true;
            if (other.transform.GetComponent<floatObject>())
            {
                other.transform.GetComponent<floatObject>().originalPosition = newPlace.position;
                other.transform.GetComponent<floatObject>().activated = false;

            }
            if (other.transform.GetComponent<fallObject>())
            {
                other.transform.GetComponent<fallObject>().originalPosition = newPlace.position;
                other.transform.GetComponent<fallObject>().activated = false;
            }

            if (other.transform.GetComponent<pullObject>())
            {
                other.transform.GetComponent<pullObject>().originalPosition = newPlace.position;
                other.transform.GetComponent<pullObject>().activated = false;
            }

            if (other.transform.GetComponent<pushObject>())
            {
                other.transform.GetComponent<pushObject>().originalPosition = newPlace.position;
                other.transform.GetComponent<pushObject>().activated = false;
            }
            other.transform.position = newPlace.position;
            panCamera();
        }
    }

    void panCamera()
    {
        if (checkCamera(this.camera1))
        {
            this.camera2.GetComponent<playerCamera>().panning = true;
            this.playerControl.gameObject.SetActive(false);
        }

        else if (checkCamera(this.camera2))
        {
            this.camera1.GetComponent<playerCamera>().panning = true;
            this.playerControl.gameObject.SetActive(false);
        }
    }

    bool checkCamera(Camera camera)
    {
        Vector3 cameraRay = camera.WorldToViewportPoint(this.transform.position);
        return cameraRay.x <= 1 && cameraRay.x >= 0 && cameraRay.y <= 1 && cameraRay.y >= 0;
    }

    bool checkPanningFinish(Camera camera)
    {
        return camera.transform.position.x == this.newPlace.transform.position.x;
    }
}