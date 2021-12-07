using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onClickEvent : MonoBehaviour
{
    public GameObject objetoActivable;
    public bool encender = true;

    [SerializeField] private FinalDiaSystem finalDia;

    //Pequeño pop para resaltar que el objeto es interactuable
    void OnMouseEnter()
    {
        this.transform.localScale += new Vector3(0.15f, 0.15f, 0);
    }

    void OnMouseExit()
    {
        this.transform.localScale -= new Vector3(0.15f, 0.15f, 0);
    }

    void OnMouseDown()
    {
        //Activa objeto y se destruye a si mismo

        this.transform.localScale -= new Vector3(0.15f, 0.15f, 0);

        //Encener/Apagar objeto
        if (encender) { objetoActivable.SetActive(true); }
        else { 
            objetoActivable.SetActive(false);
            finalDia.ShowFinalDayUI();
        }
        //Destruir script, para no poder hacer el minijuego varias veces
        Destroy(this);

    }
}
