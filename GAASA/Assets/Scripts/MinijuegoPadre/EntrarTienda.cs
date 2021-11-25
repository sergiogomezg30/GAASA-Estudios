using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntrarTienda : MonoBehaviour
{
    public GameObject objetoActivable;
    
    void OnMouseEnter()
    {
        this.transform.localScale += new Vector3(0.1f, 0.1f, 0);
    }

    void OnMouseExit(){
        this.transform.localScale -= new Vector3(0.1f, 0.1f, 0);
    }
    
    void OnMouseDown()
    {
        objetoActivable.SetActive(true);
    }
}
