using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Transform[] posiciones;
    int posicionArray;
    //public bool isGrounded;
    //Rigidbody rg;
    public float potencia;
    // Start is called before the first frame update
    void Start()
    {
        posicionArray = 1;
         //rg = GetComponent <Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Usando los Inputs, el personaje del jugador va intercambiandose de posición entre las tres posiciones posibles. 
        // if (isGrounded) { 
        if ((Input.GetButtonDown("Right"))&&(posicionArray!=2))
        {
            posicionArray++;
            transform.position = posiciones[posicionArray].position;
        }

        if ((Input.GetButtonDown("Left")) && (posicionArray != 0))
        {
            posicionArray--;
            transform.position = posiciones[posicionArray].position;
        }
            
        //}

        //if ((Input.GetButtonDown("Jump")) && (isGrounded))
        //{
        //    rg.AddForce(transform.up * potencia);
        //}
    }
}
