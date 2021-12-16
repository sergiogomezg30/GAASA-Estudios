using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonidoInteractuable : MonoBehaviour
{
    public AudioClip mouseEncima;
    public AudioClip mouseClic;

    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    void OnMouseEnter()
    {
        audioSource.PlayOneShot(mouseEncima);
    }

    void OnMouseDown()
    {
        audioSource.PlayOneShot(mouseClic);
    }
}
