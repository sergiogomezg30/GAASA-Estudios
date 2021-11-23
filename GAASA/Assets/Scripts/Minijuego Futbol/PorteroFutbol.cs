using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteroFutbol : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Parada");
    }
}
