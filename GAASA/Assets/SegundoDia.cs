using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegundoDia : MonoBehaviour
{
    public bool herramientas = false;
    public GameObject indicadorSubir;
    public GameObject puertaDesbloqueada;
    public GameObject herramientasUI;
    public GameObject objetosInteractuables;

    // Update is called once per frame
    void Update()
    {
        if (herramientas)
        {
            //Desactivamos los objetos con los que aun no hemos interactuado
            objetosInteractuables.SetActive(false);

            //activamos el icono de las herramientas UI
            herramientasUI.SetActive(true);

            //abrimos la puerta
            puertaDesbloqueada.SetActive(true);

            //Desactivamos la flechita de subir al desvan
            indicadorSubir.SetActive(false);
        }
    }
}
