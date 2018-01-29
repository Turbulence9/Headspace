using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawSound : MonoBehaviour {

    public AudioClip drawSoft;
    public AudioClip drawHard;
    private AudioSource source;

	// Use this for initialization
	void Awake () {
        source = GetComponent<AudioSource>();
	}

    void OnLaserEnter (Collision coll)
    {
        source.PlayOneShot(drawSoft, 1f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
