using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioTrack : MonoBehaviour {
    public GameObject albumSimple;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.activeSelf)
        {
            albumSimple.SetActive(true);
            albumSimple.GetComponent<AudioSource>().Play();
        }	
	}
}
