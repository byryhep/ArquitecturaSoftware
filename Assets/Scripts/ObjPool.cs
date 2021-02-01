using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPool : MonoBehaviour
{

    //Declaramos el prefab que vamos a usar en la Pool.
    [SerializeField]
    private GameObject prefab;

    //Declaramos el tamaño de las listas y si son expandibles o no. 
    [SerializeField]
    private int tamaño;

    [SerializeField]
    private bool expandible;

    //Declaramos las listas de objetos usados y libres de la Pool.
    private List<GameObject> libres;
    private List<GameObject> usados;

    private void Awake()
    {
        //Inicializa las listas y crea tantos prefabs como tamaño le hayamos puesto a la lista. 
        libres = new List<GameObject>();
        usados = new List<GameObject>();

        for(int i=0; i < tamaño; ++i)
        {
            CrearObjeto();
        }

        

    }

    public GameObject CogerObjeto()
    {
        //Detectamos si hay objetos libres en la lista, si no los hay y no es extensible llama a la funcion Crear Objeto.
        int totalLibres = libres.Count;
        if ((totalLibres== 0) && !expandible) return null;
        else if (totalLibres== 0) CrearObjeto();

        //Una vez nos hemos asegurado que haya un objeto libre, asigna ese objeto a la variable obj, quita 1 objeto de la lista de libres
        // lo añade a la de usados y devuelve obj.
        GameObject obj = libres[totalLibres-1];
        libres.RemoveAt(totalLibres - 1);
        usados.Add(obj);
        return obj;
    }

    //Recibe un objeto y lo devuelve a la lista de libres a la vez que lo desactiva y añade a la lista de usados.
    public void DevolverObjeto(GameObject obj)
    {
        obj.SetActive(false);
        usados.Remove(obj);
        libres.Add(obj);

    }

    //Cuando se llama a esta función, instancia un prefab, lo emparenta a este Objeto, lo desactiva y lo añade a la lista de libres.
    private void CrearObjeto()
    {
        GameObject obj = Instantiate(prefab);
        obj.transform.parent = transform;
        obj.SetActive(false);
        libres.Add(obj);

    }
}
