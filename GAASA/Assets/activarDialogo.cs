using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activarDialogo : MonoBehaviour
{
    public GameObject dialogo;
    public GameObject esteTrigger;

    private void OnTriggerEnter(Collider other)

    {
        if (other.CompareTag("Player"))
        {
            dialogo.SetActive(true);
            esteTrigger.SetActive(false);
        }
            
    }

}
