using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coche : MonoBehaviour
{
    public int carHP = 10;
    public Slider slider;
    private float timeElapsed = 0;
    public GameObject[] objetos;
    [SerializeField]
    private float manadaJabalies = 90;


    void Update()
    {
        slider.value = timeElapsed;
        timeElapsed += Time.deltaTime;

        if (carHP <=0)
        {
            Destroy(gameObject);
        }


        //Si el jugador ha sobrevivido durante al menos 1 minuto y medio, una manada de jabalies entorpecera el paso
        if (timeElapsed >= manadaJabalies)
        {
            objetos[0].SetActive(true);
            objetos[1].SetActive(true);
        }
        
    }
}
