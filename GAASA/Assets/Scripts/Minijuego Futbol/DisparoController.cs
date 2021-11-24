using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoController : MonoBehaviour
{
    private PorteriaController porteriaController;

    void Start()
    {
        porteriaController = transform.parent.GetComponent<PorteriaController>();
    }

    private void OnMouseDown()
    {
        porteriaController.PorteroPara(this);
        Debug.Log(gameObject.name);
    }

    private void OnTriggerEnter(Collider collision)
    {
        porteriaController.GolDeLaIA();
    }
}
