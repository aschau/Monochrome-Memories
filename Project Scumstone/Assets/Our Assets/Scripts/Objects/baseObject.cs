﻿using UnityEngine;
using System.Collections;

public abstract class baseObject : MonoBehaviour {
    public bool activated = false, isMoving = false;
    public Color32 particleColor;
    public Vector3 originalPosition;

    [HideInInspector]
    public activateObject activation;

    public virtual void Awake()
    {
        this.activation = this.GetComponent<activateObject>();

    }

	// Use this for initialization
	public virtual void Start () {
        this.originalPosition = this.transform.position;
	}

    public virtual void FixedUpdate()
    {
        if (this.GetComponentInChildren<boxTriggers>())
        {
            if (this.isMoving && !this.GetComponentInChildren<boxTriggers>().touched)
            {
                this.checkActivated();
            }
        }

        else
        {
            if (this.isMoving)
            {
                this.checkActivated();
            }
        }
    }

    public virtual void checkActivated()
    {
        if (this.activated)
        {
            this.activate();
        }

        else
        {
            if (this.activation.dualActivation && this.activation.activated1)
            {
                this.activation.GetComponent<ParticleSystem>().startColor = this.particleColor;
            }

            this.deactivate();
        }
    }

    public virtual void activate()
    {

    }

    public virtual void deactivate()
    {
        if (this.activation.activatedScript1 == this.GetType().Name && !this.activation.dualActivation)
        {
            this.activation.activated1 = false;
        }
        
        else if (this.activation.activatedScript1 == this.GetType().Name)
        {
            this.activation.activated1 = false;
        }

        else if (this.activation.activatedScript2 == this.GetType().Name)
        {
            this.activation.activated2 = false;
        }
    }
}
