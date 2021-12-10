using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class primerDia : MonoBehaviour
{
    public bool tieneLlaves = false;
    public GameObject padreSinLlaves;
    public GameObject padreConLlaves;
    public GameObject puertaDesbloqueada;
    public GameObject llavesCoche;
    public GameObject objetosInteractuables;

    // Update is called once per frame
    void Update()
    {
        if (tieneLlaves)
        {
            //Desactivamos el padre con el dialogo previo a tener llaves
            padreSinLlaves.SetActive(false);

            //Desactivamos los objetos con los que aun no hemos interactuado
            objetosInteractuables.SetActive(false);

            //activamos el icono de las llaves en la UI
            llavesCoche.SetActive(true);

            //activamos el nuevo dialogo del padre
            padreConLlaves.SetActive(true);

            //abrimos la puerta
            puertaDesbloqueada.SetActive(true);

        }
    }
}
