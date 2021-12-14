using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitarChico : MonoBehaviour
{
    public Animator fundidoNegro;
    public GameObject esteTrigger;
    public GameObject chico;

    private void OnTriggerEnter(Collider other)

    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(QuitarChico());
        }

    }

    IEnumerator QuitarChico()
    {
        
        fundidoNegro.SetTrigger("transicion");
        yield return new WaitForSeconds(1);
        chico.SetActive(false);
        Debug.Log("Quitar chico");
        esteTrigger.SetActive(false);
    }
}
