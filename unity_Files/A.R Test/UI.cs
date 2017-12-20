using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {
    private float longitude=0;
    private float latitude=0;
    [SerializeField]
    private gps gpsManager;
    [SerializeField]
    private bddRecup bdd;
    [SerializeField]
    private Text textGps;
    [SerializeField]
    private Text displayDebug;
    // 46.19572   6.110062 
    //                  Lat         Lon    Range lat  range lon
    float[] posProx = { 46.19559f, 6.110f,0.000290f,0.000504f};
    //double[] posProx = { 46.19, 6.110, 1, 1 };
    // Use this for initialization
    void Start () {
        displayDebug.text = "PLOP";
        Input.backButtonLeavesApp = true;
        textGps.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        infoGps();
        displayDebug.text = "position bd 1: " + posProx[0] + " position bd 2: " + posProx[1];
        if (longitude<(posProx[1]+ posProx[3]) && longitude> (posProx[1] - posProx[3]))
        {
            if (latitude< (posProx[0] + posProx[2]) && latitude> (posProx[0] - posProx[2]))
            {
                textGps.text = bdd.GetText();
                textGps.gameObject.SetActive(true);
            }
        }
        else
        {
            textGps.gameObject.SetActive(false);
        }
	}
    private void infoGps() {
        longitude = (float)gpsManager.Lon;
        latitude = (float)gpsManager.Lat;
        bdd.SetUrlGet(latitude, longitude);
        posProx[0] = float.Parse(bdd.GetLon());
        posProx[1] = float.Parse(bdd.GetLat());

    }
    public void sowInfos() {
        textGps.gameObject.SetActive(!textGps.gameObject.activeSelf);
    }
}
