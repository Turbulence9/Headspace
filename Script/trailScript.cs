using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailScript : MonoBehaviour
{
    public GameObject trailPrefab;
    private GameObject rightController;
    private GameObject leftController;
    private controllerManager cScript;
    private ColorPickerScript colorScript;
    private LaserPointer lScript;
    private GameObject thisTrail;
    public bool canDraw = false;
    private LineRenderer drawing;
    public AudioClip drawSound;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    void Awake()
    {
        rightController = GameObject.Find("Controller (right)");
        leftController = GameObject.Find("Controller (left)");
        cScript = rightController.GetComponent<controllerManager>();
        lScript = rightController.GetComponent<LaserPointer>();
        colorScript = leftController.GetComponent<ColorPickerScript>();
        source = GetComponent<AudioSource>();

    }
    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<Collider>().bounds.Contains(lScript.getHitPoint()))
        {
            canDraw = true;
        }
        else
        {
            canDraw = false;
        }
        if (canDraw && cScript.isTriggerDown())
        {
            //thisTrail = (GameObject)Instantiate(trailPrefab, lScript.getHitPoint(), transform.rotation, transform.parent);
            //thisTrail.GetComponent<LineRenderer>().numPositions = 100;
            //Debug.Log(thisTrail.GetComponent<LineRenderer>().numPositions);
            //drawing = thisTrail.GetComponent<LineRenderer>();

            //source.PlayOneShot(drawSound, 1f);
            //float vol = Random.Range(volLowRange, volHighRange);
        }
        if(canDraw && cScript.isTrigger())
        {

            //drawing.numPositions++;
            //drawing.SetPosition(drawing.numPositions - 1, lScript.getHitPoint());
            this.transform.parent.GetComponent<Rigidbody>().isKinematic = true;

            //thisTrail.GetComponent<LineRenderer>().numPositions = 20;
            //thisTrail.transform.position = lScript.getHitPoint();
            //thisTrail.transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("Camera (head)").transform.position, 10);
            //thisTrail.transform.LookAt(GameObject.Find("Camera (head)").transform);
            //thisTrail.GetComponent<Renderer>().material.color = colorScript.getColor();
            //GameObject pixel = Instantiate(trailPrefab, lScript.getHitPoint(), transform.rotation, transform.parent);
            //pixel.GetComponent<Renderer>().material.color = colorScript.getColor();
        } else
        {
            this.transform.parent.GetComponent<Rigidbody>().isKinematic = false;
        }
        if (cScript.isTrigger() && !source.isPlaying && canDraw)
        {
            source.Play();
        }

        if (cScript.isTriggerUp() && source.isPlaying)
        {
            source.Stop();
        }

    }

}