using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class mostrarDinero : MonoBehaviour
{
    public TextMeshProUGUI ahorrosCant;

    // Start is called before the first frame update
    void Start()
    {
        ahorrosCant.text = FinalDiaData.ahorrosMoney.ToString() + "€";
    }

}
