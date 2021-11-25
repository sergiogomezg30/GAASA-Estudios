using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalirTienda : MonoBehaviour
{
    public GameObject objetoDesactivable1;
    public GameObject objetoDesactivable2;
    public GameObject objetoDesactivable3;
    public GameObject objetoDesactivable4;
    public GameObject objetoDesactivable5;
    
    void OnMouseEnter()
    {
        this.transform.localScale += new Vector3(0.1f, 0.1f, 0);
    }

    void OnMouseExit(){
        this.transform.localScale -= new Vector3(0.1f, 0.1f, 0);
    }
    
    void OnMouseDown()
    {
        //this.SetActive(false);
        objetoDesactivable1.SetActive(false);
        objetoDesactivable2.SetActive(false);
        objetoDesactivable3.SetActive(false);
        objetoDesactivable4.SetActive(false);
        objetoDesactivable5.SetActive(false);
    }
}
