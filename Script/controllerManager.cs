using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerManager : MonoBehaviour {

    public GameObject objPrefab;
    public GameObject board;
    public GameObject head;
    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index);  }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    public bool isTrigger()
    {
        return Controller.GetHairTrigger();
    }
    public bool isTriggerDown()
    {
        return Controller.GetHairTriggerDown();
    }
    public bool isTriggerUp()
    {
        return Controller.GetHairTriggerUp();
    }
    public Vector2 getTouchPos()
    {
        return Controller.GetAxis();
    }
    public Vector3 getPos()
    {
        return transform.position;
    }
    public Quaternion getRot()
    {
        return transform.rotation;
    }
    // Update is called once per frame
    void Update () {
        if (Controller.GetAxis() != Vector2.zero)
        {
            //Debug.Log(gameObject.name + Controller.GetAxis());
        }

        if (Controller.GetHairTriggerDown())
        {

            //Debug.Log(gameObject.name + " Trigger Pressed");
        }

        if (Controller.GetHairTriggerUp())
        {
            //Debug.Log(gameObject.name + " Trigger Release");
        }

        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            //Debug.Log(gameObject.name + " Grip Press");
            if (this.name == "Controller (right)")
            {
                Instantiate(objPrefab, head.transform.position + head.transform.forward, head.transform.rotation);
            }
            if (this.name == "Controller (left)")
            {
                Instantiate(board, head.transform.position + head.transform.forward, head.transform.rotation);
            }
        }

        if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
        {
            //Debug.Log(gameObject.name + " Grip Release");
        }
	}
}
