using UnityEngine;
using System.Collections;

public class dragHandler : MonoBehaviour {
    private float offsetX;
    private float offsetY;
    private Vector3 origin;
	// Use this for initialization
	void Start () {
        origin = this.transform.position;   
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void beginDrag()
    {
        offsetX = this.transform.position.x - Input.mousePosition.x;
        offsetY = this.transform.position.y - Input.mousePosition.y;
    }

    public void onDrag()
    {
        this.transform.position = new Vector3(Input.mousePosition.x + offsetX, Input.mousePosition.y + offsetY);
    }

    public void endDrag()
    {
        this.transform.position = origin;
    }
}
