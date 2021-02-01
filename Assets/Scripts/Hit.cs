using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{



    ObjPool pool;

    void Start()
    {
        //Aqui accedemos al script de la pool de este objeto.
        pool = transform.parent.GetComponent<ObjPool>();
    }

    void Update()
    {
        //Movimiento del obstaculo dependiente de la velocidad del Game Manager.
        transform.position = new Vector3(transform.position.x + Manager.Instance.speed, transform.position.y, transform.position.z);
    }

    //Detectamos cuando el trigger del obstáculo colisiona con otro collider.
    private void OnTriggerEnter(Collider other)
    {
        //Si el objeto con el que ha colisionado es el jugardor activa la variable Bool del manager avisando que lo ha golpeado
        //e iguala la velocidad a 0.
        if (other.tag == "Player")
        {
            Manager.Instance.hit = true;
            Manager.Instance.speed = 0;

            
        }

        //Independientemente de si colisiona con el player o con el trigger tras el jugador, devuelve el objeto a la pull.
        pool.DevolverObjeto(this.gameObject);
        
        }

}


