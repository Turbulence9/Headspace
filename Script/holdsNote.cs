using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdsNote : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "note" || col.gameObject.name == "note(Clone)")
        {
            col.transform.SetParent(this.transform);
        }
    }
	
	// Update is called once per frame
	void Update () {
	}
}
