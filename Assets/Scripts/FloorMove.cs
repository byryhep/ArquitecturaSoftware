using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMove : MonoBehaviour
{
    Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        //Declaramos la posición inicial a la que volver más tarde. 
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //El suelo se va moviendo a la velocidad que le indica el Manager.
        transform.position = new Vector3(transform.position.x + Manager.Instance.speed, transform.position.y, transform.position.z); 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Cuando el collider da al player vuelve a la posicion inicial creando así un suelo infinito.
            transform.position = initialPosition;
            
        }
        
    }
}
