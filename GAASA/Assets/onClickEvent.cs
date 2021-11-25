using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onClickEvent : MonoBehaviour
{
    public GameObject objetoActivable;
    public bool sePuedeVolverAPulsar = true;

    //Pequeño pop para resaltar que el objeto es interactuable
    void OnMouseEnter()
    {
        this.transform.localScale += new Vector3(0.1f, 0.1f, 0);
    }

    void OnMouseExit()
    {
        this.transform.localScale -= new Vector3(0.1f, 0.1f, 0);
    }

    void OnMouseDown()
    {
        //Activa objeto y se destruye a si mismo
        
        this.transform.localScale -= new Vector3(0.1f, 0.1f, 0);
        objetoActivable.SetActive(true);

        if (!sePuedeVolverAPulsar) { Destroy(this); }

    }
}
