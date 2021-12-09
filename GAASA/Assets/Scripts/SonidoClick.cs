using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoClick : MonoBehaviour
{

    public AudioClip mouseEncima;
    public AudioClip mouseClic;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnMouseEnter()
    {
        audioSource.PlayOneShot(mouseEncima);
    }

    void OnMouseDown()
    {
        audioSource.PlayOneShot(mouseClic);
    }
}
