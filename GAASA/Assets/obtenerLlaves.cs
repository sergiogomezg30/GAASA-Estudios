using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obtenerLlaves : MonoBehaviour
{
    public GameObject dia1;
    // Start is called before the first frame update
    void OnMouseDown()
    {
        dia1.GetComponent<primerDia>().tieneLlaves = true;
        //Destruir script, para no poder hacer el minijuego varias veces
        Destroy(this);

    }
}
