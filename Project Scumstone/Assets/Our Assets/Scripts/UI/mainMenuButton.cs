using UnityEngine;
using System.Collections;

public abstract class mainMenuButton : MonoBehaviour {

    public virtual void Awake()
    {

    }

	// Use this for initialization
	public virtual void Start () {
	
	}
	
	// Update is called once per frame
	public virtual void Update () {
	
	}

    public virtual void onClick()
    {

    }

    public virtual void onMouseEnter()
    {
        this.transform.FindChild("Text").gameObject.SetActive(true);
    }

    public virtual void onMouseExit()
    {
        this.transform.FindChild("Text").gameObject.SetActive(false);
    }
}
