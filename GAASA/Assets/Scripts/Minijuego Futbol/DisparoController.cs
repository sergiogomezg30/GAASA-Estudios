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
        Debug.Log(gameObject.name);
    }
}
