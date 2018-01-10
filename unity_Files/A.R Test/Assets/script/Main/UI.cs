using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI : MonoBehaviour {
    private double longitude=0;
    private double latitude=0;
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
    double[] posProx = { 46.19559f, 6.110f,0.000290f,0.000504f};
    //double[] posProx = { 46.19, 6.110, 1, 1 };
    // Use this for initialization
    void Start () {
        displayDebug.text = "PLOP";
        Input.backButtonLeavesApp = true;
        textGps.gameObject.SetActive(false);
        StartCoroutine(checkGps());
	}
	
	// Update is called once per frame
	void Update () {
        

	}

    IEnumerator checkGps()
    {
        while (true)
        {
            infoGps();
            displayDebug.text = "position bd 1: " + posProx[0] + " position bd 2: " + posProx[1];
            if (longitude < (posProx[1] + posProx[3]) && longitude > (posProx[1] - posProx[3]))
            {
                if (latitude < (posProx[0] + posProx[2]) && latitude > (posProx[0] - posProx[2]))
                {
                    Debug.Log("AR mylog");
                    textGps.text = bdd.GetText();
                    textGps.gameObject.SetActive(true);
                }
            }
            else
            {
                textGps.gameObject.SetActive(false);
            }
            yield return new WaitForSeconds(10f);
        }
    }
    private void infoGps() {
        longitude = gpsManager.Lon;
        latitude  = gpsManager.Lat;
        bdd.SetUrlGet(latitude, longitude);
        posProx[0] = bdd.GetLon();
        posProx[1] = bdd.GetLat();
        displayDebug.text = posProx[0].ToString();
    }
    public void sowInfos() {
        textGps.gameObject.SetActive(!textGps.gameObject.activeSelf);
    }
}
