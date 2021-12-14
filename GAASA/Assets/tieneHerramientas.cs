using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tieneHerramientas : MonoBehaviour
{
    public GameObject dia2;
    // Start is called before the first frame update
    void OnMouseDown()
    {
        dia2.GetComponent<SegundoDia>().herramientas = true;
        //Destruir script, para no poder hacer el minijuego varias veces
        Destroy(this);

    }
}
