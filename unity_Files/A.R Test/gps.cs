using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gps : MonoBehaviour {
    [SerializeField]
    private Text gpsData;
     private double lon=0;
     private double lat=0;

    public double Lon
    {
        get
        {
            return lon;
        }

        private set
        {

            lon = value;
        }
    }

    public double Lat
    {
        get
        {
            return lat;
        }

        private set
        {
            lat = value;
        }
    }

    // Use this for initialization
    void Start () {
        StartCoroutine(TimerRecord());
    }
    public void StartRecord()
    {
        
    }
    public void getNewData()
    {
        StopCoroutine(CheckGps());
        StartCoroutine(CheckGps());
    }
    IEnumerator CheckGps()
    {
        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
            yield break;

        // Start service before querying location
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            gpsData.text = maxWait.ToString();
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            gpsData.text = "Timed out";
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            gpsData.text = "Unable to determine device location";
            yield break;
        }
        else
        {
            Lat = Input.location.lastData.latitude;
            lon = Input.location.lastData.longitude;
            // Access granted and location value could be retrieved
            gpsData.text = "Latitude: " + Input.location.lastData.latitude + "\n Longitude: " + Input.location.lastData.longitude + "\n  altitude: " + Input.location.lastData.altitude + "\n Horizontal accurency: " + Input.location.lastData.horizontalAccuracy + "\n timestamp: " + Input.location.lastData.timestamp;
            Lon = Input.location.lastData.longitude;
            Lat = Input.location.lastData.latitude;
        }
        Input.location.Stop();
    }
    IEnumerator TimerRecord() {
        while (true)
        {
            StartCoroutine(CheckGps());
            yield return new WaitForSeconds(20);
        }
    }
}
