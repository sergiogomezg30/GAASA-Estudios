using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activarPorteria : MonoBehaviour
{
    public GameObject porteria1;
    public GameObject porteria2;
    public GameObject chico;
    public GameObject esteTrigger;
    public GameObject QuitarChicoTrigger;

    private void OnTriggerEnter(Collider other)

    {
        if (other.CompareTag("Player"))
        {
            QuitarChicoTrigger.SetActive(true);
            chico.SetActive(true);
            porteria1.SetActive(false);
            porteria2.SetActive(true);
            esteTrigger.SetActive(false);
        }

    }

}
