using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    [SerializeField]
    bool isLastCoin;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        //Se mueve la moneda con la velocidad que le declara el Manager.
        transform.position = new Vector3(transform.position.x + Manager.Instance.speed, transform.position.y, transform.position.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        //Si entra en contacto con el player se recoge y se actualiza el número de monedas.
        if (other.tag == "Player")
        {
            Manager.Instance.Coins++;
            Text texto = GameObject.Find("TextoMonedas").GetComponent<Text>();
            texto.text = "Monedas: " +Manager.Instance.Coins.ToString();


        }
       //Si es cogida por el player o collisiona contra el trigger tras este se destruye.
            Destroy(this.gameObject);

        //Si es la última moneda del grupo, destruye también al padre.
        if (isLastCoin) Destroy(transform.parent.gameObject);
    }
}
