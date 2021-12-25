using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dia3GameManager : MonoBehaviour
{
    //[SerializeField] private InteractionsHandler interactionsHandler;

    [SerializeField] private Animator fundidoNegro;
    [SerializeField] private GameObject chicoParadaBus;

    [SerializeField] private GameObject chicoPorteria;
    [SerializeField] private GameObject porteria1;
    [SerializeField] private GameObject porteria2;

    private void Start()
    {
        GameEvents.Instance.onFinishDialogue += CheckQuitarChico;
    }

    private void CheckQuitarChico(string npcName)
    {
        NPC npcChicoBus = chicoParadaBus.gameObject.GetComponent<NPC>();    //solo queremos que se active con ese NPC en concreto
        if (npcName == npcChicoBus.GetNameNPC()) {
            StartCoroutine(QuitarChico());
        }
    }

    //funciones de Gonzalo adaptadas al GameEvents por Adrián
    IEnumerator QuitarChico()
    {

        fundidoNegro.SetTrigger("transicion");
        yield return new WaitForSeconds(1);
        chicoParadaBus.SetActive(false);
        Debug.Log("Quitar chico");
        //esteTrigger.SetActive(false);

        ActivarPorteria();

        GameEvents.Instance.onFinishDialogue -= CheckQuitarChico;
    }

    private void ActivarPorteria()
    {
        //QuitarChicoTrigger.SetActive(true);
        chicoPorteria.SetActive(true);
        porteria1.SetActive(false);
        porteria2.SetActive(true);
        //esteTrigger.SetActive(false);
    }
}
