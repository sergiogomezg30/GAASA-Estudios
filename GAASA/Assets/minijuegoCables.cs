using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minijuegoCables : MonoBehaviour
{
    public GameObject botonSalir;
    public int cablesConectados = 0;

    // Update is called once per frame
    void Update()
    {
        if (cablesConectados >= 4)
        {
            botonSalir.SetActive(true);
        }
    }
}
