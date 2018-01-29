using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strokeController : MonoBehaviour {

    public int startSize;
    private int strokeSize;
    private GameObject rightController;
    private controllerManager cScript;
    private float startXpos;
    // Use this for initialization
    void Awake () {
        rightController = GameObject.Find("Controller (right)");
        cScript = rightController.GetComponent<controllerManager>();
        startXpos = transform.position.x;
    }
	
    public int getStrokeSize()
    {
        return strokeSize;
    }

	// Update is called once per frame
	void Update () {
        if (cScript.getTouchPos() != Vector2.zero)
        {
            //Debug.Log(startSize + Mathf.RoundToInt(cScript.getTouchPos().x * 0.8f * startSize));
            strokeSize = startSize + Mathf.RoundToInt(cScript.getTouchPos().x * 0.8f * startSize);
            //transform.position = new Vector3(startXpos + cScript.getTouchPos().x * 0.1f, transform.position.y, transform.position.z);
            transform.localScale = new Vector3(0.00083333333f * strokeSize, 0.0005f, 0.00083333333f * strokeSize);
        } else
        {
            strokeSize = 24;
        }
    }
}
