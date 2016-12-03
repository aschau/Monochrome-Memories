using UnityEngine;
using System.Collections;

public abstract class baseObject : MonoBehaviour {
    public bool activated = false;
    public Color32 particleColor;

    public virtual void Awake()
    {

    }

	// Use this for initialization
	public virtual void Start () {
	
	}

    public virtual void FixedUpdate()
    {
        this.checkActivated();
    }

    public virtual void checkActivated()
    {
        if (this.activated)
        {
            this.activate();
        }

        else
        {
            if (this.GetComponent<activateObject>().dualActivation && this.GetComponent<activateObject>().activated1)
            {
                this.GetComponent<activateObject>().GetComponent<ParticleSystem>().startColor = this.particleColor;
            }
        }
    }

    public virtual void activate()
    {

    }
}
