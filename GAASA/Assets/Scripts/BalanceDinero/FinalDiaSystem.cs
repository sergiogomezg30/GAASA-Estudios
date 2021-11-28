using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalDiaSystem : MonoBehaviour
{
    [SerializeField] private BaseDia[] dias;   //un array para almacenar todos los dias de la semana e ir usandolos
    private int posDiaActual;

    [SerializeField] private TextMeshProUGUI numeroDia;
    [SerializeField] private TextMeshProUGUI descripcionDia;

    void Start()
    {
        //para testear, aunque esto deberia estar inicializado en otro lado
        FinalDiaData.diaActual = 1;
        FinalDiaData.ahorrosMoney = 1000;
        ///////////////////////////////////////////////////////////////////
        
        posDiaActual = FinalDiaData.diaActual - 1;

        numeroDia.text = "Final Día " + dias[posDiaActual].dia.ToString();
        descripcionDia.text = dias[posDiaActual].descriptionDia;
    }
}
