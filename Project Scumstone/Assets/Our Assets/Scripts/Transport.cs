using UnityEngine;
using System.Collections;

public class Transport : MonoBehaviour
{
    public float speed = 10f, delay = 1.2f;
    public Transform newPlace;
    private Camera camera1, camera2;
    private bool activated = false;
    // Use this for initialization
    void Start()
    {
        this.camera1 = GameObject.Find("Black Camera").GetComponent<Camera>();
        this.camera2 = GameObject.Find("White Camera").GetComponent<Camera>();
        this.newPlace = this.transform.Find("newPlace");
        this.delay = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (camera1.GetComponent<playerCamera>().panning && this.activated)
        {
            Debug.Log(newPlace.transform.position.x);

            this.camera1.transform.position = Vector3.MoveTowards(this.camera1.transform.position, new Vector3(newPlace.transform.position.x, this.camera1.transform.position.y, this.camera1.transform.position.z), this.speed * Time.deltaTime);
            if (checkPanningFinish(camera1))
            {
                StartCoroutine(panningOff(this.camera1, this.delay));
            }
        }

        else if (camera2.GetComponent<playerCamera>().panning && this.activated)
        {
            this.camera2.transform.position = Vector3.MoveTowards(this.camera2.transform.position, new Vector3(newPlace.transform.position.x, this.camera2.transform.position.y, this.camera2.transform.position.z), this.speed * Time.deltaTime);
            if (checkPanningFinish(camera2))
            {
                StartCoroutine(panningOff(this.camera2, this.delay));
            }
        }
    }

    IEnumerator panningOff(Camera camera, float delay)
    {
        yield return new WaitForSeconds(delay);
        camera.GetComponent<playerCamera>().panning = false;
        this.activated = false;
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
        }

        else if (checkCamera(this.camera2))
        {
            this.camera1.GetComponent<playerCamera>().panning = true;
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