using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Manager : MonoBehaviour
{

    //Aqui creamos el patrón Singleton.

    private static Manager _instance;

    public static Manager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject gm = new GameObject("GameManager");
                gm.AddComponent<Manager>();
            }

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }



    //Aquí están declaradas las variables.
    public float speed, respawnCD, minCD;   
    public float Score;
    public int Coins;
    Text textScore;
    public bool hit;

    void Start()
    {
        //Accedemos al script de Texto para poner la puntuación.
        textScore = GameObject.Find("Puntuacion").GetComponent<Text>();
        //Inicializamos el booleano que indica si han golpeado al player como falso.
        hit = false;
    }

    void Update()
    {
        //Si no has recibido un golpe, se va sumando la puntuación y velocidad a la que va además de el tiempo de respawn de obstaculos.
        if (!hit) { 

            speed += Time.deltaTime/150;
            Score += speed*Time.deltaTime*40;
            if (respawnCD > minCD) {

                respawnCD -= Time.deltaTime/100;
                
                    
            }
            
        }
        //Esto va actualizando todo el rato la puntuación en pantalla. 
        textScore.text = "Puntuacion: "+Score.ToString("F0");
    }
}
