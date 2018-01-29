using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    public GameObject laserPrefab;
    private GameObject laser;
    private Transform laserTransform;
    private Vector3 hitPoint;
    private RaycastHit hit;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    private void ShowLaser(RaycastHit hit)
    {
        laser.SetActive(true);
        laserTransform.position = Vector3.Lerp(trackedObj.transform.position, hitPoint, .5f);
        laserTransform.LookAt(hitPoint);
        laserTransform.localScale = new Vector3(laserTransform.localScale.x, laserTransform.localScale.y, hit.distance);
    }

    public Vector3 getHitPoint()
    {
        return hitPoint;
    }
	
    public Vector2 getTextureCoord()
    {
        return hit.textureCoord;
    }

    void Start ()
    {
        laser = Instantiate(laserPrefab);
        laserTransform = laser.transform;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //hit = null;

        if(Physics.Raycast(trackedObj.transform.position, transform.forward, out hit, 100))
        {
            hitPoint = hit.point;
            ShowLaser(hit);
        }
        //Debug.Log(hit.textureCoord.x);
    }
}
