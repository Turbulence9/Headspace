using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawTexture : MonoBehaviour {

    private GameObject rightController;
    private GameObject leftController;
    private GameObject strokeIcon;
    private strokeController strokeScript;
    private ColorPickerScript colorScript;
    private LaserPointer lScript;
    private controllerManager cScript;
    private Texture2D canvasTexture;
    private Color curColor;
    //private Texture2D thisCanvasTexture;
    public int size;
    //public int strokeSize;
    private int radius;
    // Use this for initialization
    void Awake() {
        rightController = GameObject.Find("Controller (right)");
        leftController = GameObject.Find("Controller (left)");
        strokeIcon = GameObject.Find("strokeIcon");
        strokeScript = strokeIcon.GetComponent<strokeController>();
        colorScript = leftController.GetComponent<ColorPickerScript>();
        lScript = rightController.GetComponent<LaserPointer>();
        cScript = rightController.GetComponent<controllerManager>();
        //thisCanvasTexture = Instantiate(canvasTexture) as Texture2D;
        canvasTexture = new Texture2D(size, size);
        this.GetComponent<Renderer>().material.mainTexture = canvasTexture;
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("HitPoint: " + lScript.getHitPoint() + "this: " + this.transform.position + "Dif: " + (lScript.getHitPoint() - this.transform.position));
        //Debug.Log(lScript.getHitPoint().x - this.transform.position.x);
        if (cScript.isTrigger() && transform.parent.Find("innerNote").GetComponent<trailScript>().canDraw && lScript.getTextureCoord() != Vector2.zero)
        {
            //Debug.Log("sadasdasdad");
            //Debug.Log(Mathf.RoundToInt(lScript.getTextureCoord().x * 320) + " " + Mathf.RoundToInt(lScript.getTextureCoord().y * 320));


            int midPointX = Mathf.RoundToInt(lScript.getTextureCoord().x * size);
            int midPointY = Mathf.RoundToInt(lScript.getTextureCoord().y * size);
            curColor = colorScript.getColor();
            radius = (strokeScript.getStrokeSize() - 1) / 2;
            //for (int i = 0; i < strokeSize; i++)
            //{
            //for (int j = 0; j < strokeSize; j++)
            //{
            //canvasTexture.SetPixel(midPointX-((strokeSize-1)/2)+j,midPointY - ((strokeSize - 1) / 2) + i, colorScript.getColor());
            //}
            //}


            for (int x = midPointX - radius; x <= midPointX; x++)
            {
                for (int y = midPointY - radius; y <= midPointY; y++)
                {
                    // we don't have to take the square root, it's slow
                    if ((x - midPointX) * (x - midPointX) + (y - midPointY) * (y - midPointY) <= radius * radius)
                    {
                        int xSym = midPointX - (x - midPointX);
                        int ySym = midPointY - (y - midPointY);
                        // (x, y), (x, ySym), (xSym , y), (xSym, ySym) are in the circle
                        if(x >= 0 && x <= size && y >= 0 && y <= size)
                        {
                            canvasTexture.SetPixel(x, y, curColor);
                            if(ySym >= 0 && ySym <= size)
                            {
                                canvasTexture.SetPixel(x, ySym, curColor);
                                if(xSym >= 0 && xSym <= size)
                                {
                                    canvasTexture.SetPixel(xSym, y, curColor);
                                    canvasTexture.SetPixel(xSym, ySym, curColor);
                                }
                            }
                        }
                    }
                }
            }

            canvasTexture.Apply();
            //Debug.Log(canvasTexture);
            //this.GetComponent<Renderer>().material.mainTexture = canvasTexture;
        }
	}
}
