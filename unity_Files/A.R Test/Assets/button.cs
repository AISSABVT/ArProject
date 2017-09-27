using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class button : MonoBehaviour,IVirtualButtonEventHandler {
    public Text debug;
    string[] motaleatoire = { "T'as réussis bravo !", "genial", "Ce test marche" };
	// Use this for initialization
	void Start () {
        gameObject.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
	}
    public void OnButtonPress(VirtualButtonAbstractBehaviour vb) { }
    public void OnButtonPressed(VirtualButtonAbstractBehaviour vb) {
        debug.text = motaleatoire[Random.Range(0,3)];
    }
    public void OnButtonReleased(VirtualButtonAbstractBehaviour vb) {
        
    }
}
