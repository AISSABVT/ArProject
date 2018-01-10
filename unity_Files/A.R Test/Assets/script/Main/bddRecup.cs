using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bddRecup : MonoBehaviour {

    private string url = "";//url cible
    private string dataGps="-";
    /// <summary>
    /// Des le début charge la page cible et une fois chargée en récupère le texte( html plein) et les images(en textures);
    /// </summary>
    /// <returns></returns>
    public void SetUrlGet(double lat,double lon) {
        url = "http://goldenslothstudio.com/ArProject/arProject.php?lat=" + lat + "&lon=" + lon;
        RecupInfos();
    }
    public IEnumerator RecupInfos()
    {
        WWW www = new WWW(url);//creation de l'objet www avec en parametre la page cible
        yield return www;//attente du chargement de la page
        dataGps = www.text;//l'objet text dans unity affiche le texte de la page
    }
    /// <summary>
    /// Récupération de la latitude retourner par la bdd
    /// </summary>
    /// <returns></returns>
    public double GetLat()
    {
        double lattiBdd = 0;
        string[] latBdd;
        latBdd=dataGps.Split('-');
        lattiBdd=System.Convert.ToDouble(latBdd[0]);
        lattiBdd= (double)float.Parse(latBdd[0]);
        return lattiBdd;
    }
    /// <summary>
    /// Récupération de la longitude retourner par la bdd
    /// </summary>
    /// <returns></returns>
    public double GetLon() {
        double longBdd = 0;
        string[] lonBdd;
        print(dataGps.Split('-'));
        lonBdd =dataGps.Split('-');
        longBdd =(double)float.Parse(lonBdd[1]);
        return longBdd;
    }
    /// <summary>
    /// Récuperation du texte retourner par la bdd
    /// </summary>
    /// <returns></returns>
    public string GetText()
    {
        string[] txtBdd;
        txtBdd = dataGps.Split('-');
        return txtBdd[2];
    }
}
