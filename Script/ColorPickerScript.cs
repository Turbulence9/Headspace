using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPickerScript : MonoBehaviour {

    private GameObject leftController;
    private controllerManager cScript;
    public Texture2D colorWheel;
    public Color color;
    public Material selectedColor;


    void Awake()
    {
        leftController = GameObject.Find("Controller (left)");
        cScript = leftController.GetComponent<controllerManager>();
    }

    public Color getColor()
    {
        return color;
    }

        // Update is called once per frame
        void Update () {
        if (cScript.getTouchPos() != Vector2.zero)
        {
            color = colorWheel.GetPixel(Mathf.RoundToInt(cScript.getTouchPos().x * 365 + 365), Mathf.RoundToInt(cScript.getTouchPos().y * 365 + 365));
        }
        selectedColor.SetColor("_Color", color);
	}
}
