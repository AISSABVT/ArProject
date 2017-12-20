<?php
/*
 * connection à la base de données
 */
DEFINE("DB_HOST","127.0.0.1");
DEFINE("DB_NAME","arProject");
DEFINE("DB_USER","root");
DEFINE("DB_PASS","");

if (isset($_GET["lat"])&&isset($_GET["lon"])) {
    //fetch sur la bd
    $retour=getLocations($_GET["lat"],$_GET["lon"]);
    foreach ($retour as $value) {
        echo $value["lat"]."-".$value["lon"].";";
    }    
}
//http://127.0.0.1/my%20portable%20files/ArProject/arProject.php?lat=46.19572&lon=6.110062

//connexion a la base de données
function getConnexion(){
    static $dbb=null;
    if($dbb==null){
        try{
        $connectionString="mysql:host=".DB_HOST.";dbname=".DB_NAME."";
        $dbb=new PDO($connectionString,DB_USER,DB_PASS);
        $dbb->setAttribute(PDO::ATTR_ERRMODE,PDO::ERRMODE_EXCEPTION);
        }
        catch(PDOException $e){
            die('Erreur : '. $e->getMessage() );
        }
    }
    return $dbb;
}
/*
 * Recupère les infos sur la base de donnée
 */
function getLocations($lat,$lon){
    $errLat=0.0005;
    $errLon=0.000504;
    $connexion=getConnexion();
    $request=$connexion->prepare("SELECT * FROM `positions` WHERE (`lat` BETWEEN (:lat-".$errLat.") AND (:lat +".$errLat.")) AND `lon` BETWEEN (:lon- ".$errLon.") AND (:lon + ".$errLon.")");
    $request->bindParam(':lat',$lat,PDO::PARAM_STR);
    $request->bindParam(':lon',$lon,PDO::PARAM_STR);
    $request->execute();
    $resulat=$request->fetchAll(PDO::FETCH_ASSOC);
    return $resulat;
}

