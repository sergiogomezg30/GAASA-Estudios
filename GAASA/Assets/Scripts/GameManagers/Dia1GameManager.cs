using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dia1GameManager : MonoBehaviour
{
    [SerializeField] private GameObject dialogoSalirCasa;

    private void Start()
    {
        GameEvents.Instance.onDoorExit += TurnOnDialogoSalirCasa;
    }

    private void TurnOnDialogoSalirCasa()
    {
        dialogoSalirCasa.SetActive(true);
        GameEvents.Instance.onDoorExit -= TurnOnDialogoSalirCasa;   //lo quitamos nada más llamarlo porque solo lo queremos usar una vez
    }
}
