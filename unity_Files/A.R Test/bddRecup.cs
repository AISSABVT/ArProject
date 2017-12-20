using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bddRecup : MonoBehaviour {

    private string url = "";//url cible
    private string dataGps;
    /// <summary>
    /// Des le début charge la page cible et une fois chargée en récupère le texte( html plein) et les images(en textures);
    /// </summary>
    /// <returns></returns>
    public void SetUrlGet(float lat,float lon) {
        url = "http://goldenslothstudio.com/ArProject/arProject.php?lat=" + lat + "&lon=" + lon;
        RecupInfos();
    }
    public IEnumerator RecupInfos()
    {
        WWW www = new WWW(url);//creation de l'objet www avec en parametre la page cible
        yield return www;//attente du chargement de la page
        dataGps = www.text;//l'objet text dans unity affiche le texte de la page
    }
    public string GetLat()
    {
        string[] plop;
        plop=dataGps.Split('-');
        return plop[0];
    }
    public string GetLon() {
        string[] plop;
        plop=dataGps.Split('-');
        
        return plop[1];
    }
    public string GetText()
    {
        string[] plop;
        plop = dataGps.Split('-');
        return plop[2];
    }
}
