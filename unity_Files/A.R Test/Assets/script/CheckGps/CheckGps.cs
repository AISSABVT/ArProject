using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CheckGps : MonoBehaviour {
    [SerializeField]
    private Text NoGpsMessage;
	// Use this for initialization
	void Start () {
        NoGpsMessage.text = "";
        if (Input.location.isEnabledByUser)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            StartCoroutine(checkGps());  
        }
	}

    IEnumerator checkGps()
    {
        for (int i = 0; i < 20; i++)
        {
            if (Input.location.isEnabledByUser)
            {
                SceneManager.LoadScene(1);
            }
            else {
                NoGpsMessage.text = "Gps not enabled, please activate it";
                yield return new WaitForSeconds(1.0f);
            }
        }
    }
}
