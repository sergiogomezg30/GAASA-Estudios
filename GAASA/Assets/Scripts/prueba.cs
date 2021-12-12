using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prueba : MonoBehaviour
{

    public AudioClip sonidoChoque;
    public GameObject coche;
    private AudioSource audioSource;

    void choque()
    {
        audioSource.PlayOneShot(sonidoChoque);
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //if(coche.carHP <=0){
            //choque();
        //}
    }
}
