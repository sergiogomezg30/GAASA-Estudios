using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onClickEvent : MonoBehaviour
{
    public GameObject minijuego;

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
        minijuego.SetActive(true);
    }
}
