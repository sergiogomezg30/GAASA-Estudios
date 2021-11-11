using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coche : MonoBehaviour
{
    public int carHP = 10;
    public Text distanceDisplay;
    public float timeElapsed = 0;

    //He creado un Scr nuevo para coche en lugar de simplemente añadir
    //la variable HP a controlPersonaje para poder gestionar otros aspectos
    //cuando toque pulir a traves de este script. Por ejemplo, el coche podria
    //tener varios sprites y segun como de dañado este se muestre uno u otro.
    //el coche tambien podria tener un generador de particulas en el tubo de escape
    //que podemos gestionar en este script (sale mas si se mueve hacia delante, 
    //implicando que acelera, se spawnean menos particulas si vas hacia atras)

    void Update()
    {
        distanceDisplay.text = timeElapsed.ToString();
        timeElapsed += Time.deltaTime;

        if (carHP <=0)
        {
            Destroy(gameObject);
        }

        
    }
}
