using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteroFutbol : MonoBehaviour
{
    [SerializeField] private PorteriaController porteriaController;
    private void OnCollisionEnter(Collision collision)
    {
        porteriaController.ParadaDelPlayer();
    }
}
