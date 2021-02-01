using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    //Declaramos todas las variables que vamos a utilizar. 
    public Transform[] posiciones,Posicionesmoneda;
    int posicionArray;
    float  cdactivo;
    public GameObject prefabcoin;
    public ObjPool[] poolObstacle;
    int ObstacleType;
    GameObject g;

    // Start is called before the first frame update
    void Start()
    {
        
        cdactivo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Si no esta activo el CD de respawn, crea un número aleatorio de 0 a 3 y crea un obstaculo distinto dependiendo del número que salga. 
        if (cdactivo <= 0)
        {
            ObstacleType=  Random.Range(0, 4);
            switch (ObstacleType) 
            {
                case 0:
                    //Cogemos un objeto de una pool en concreto y la activamos. 
                    posicionArray = Random.Range(0, 3);
                    g = poolObstacle[1].CogerObjeto();
                    g.transform.position = posiciones[posicionArray].position;
                    g.transform.rotation = posiciones[posicionArray].rotation;
                    g.SetActive(true);
                    break;
               
                case 1:

                    g = poolObstacle[1].CogerObjeto();
                    g.transform.position = posiciones[1].position;
                    g.transform.rotation = posiciones[1].rotation;
                    g.SetActive(true);
                    break;
                
                case 2:

                    g = poolObstacle[2].CogerObjeto();
                    g.transform.position = posiciones[1].position;
                    g.transform.rotation = posiciones[1].rotation;
                    g.SetActive(true);
                    break;

                case 3:

                    g = poolObstacle[3].CogerObjeto();
                    Debug.Log(g);
                    g.transform.position = posiciones[1].position;
                    g.transform.rotation = posiciones[1].rotation;
                    g.SetActive(true);
                    break;
            }
            //Pone de cooldown el que le indique el manager. 
            cdactivo = Manager.Instance.respawnCD;

            //También se instancia en una de las 3 posiciones de manera aleatoria el prefab que contiene las monedas.
            posicionArray = Random.Range(0, 3);
            Instantiate(prefabcoin, Posicionesmoneda[posicionArray].position, posiciones[posicionArray].rotation);

        }

        //Va reduciendo el cd hasta que se vuelva a resetear. 
        cdactivo = cdactivo - Time.deltaTime;
    }
    
    
}
