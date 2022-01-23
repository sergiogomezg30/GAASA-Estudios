using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThinkFutbol : MonoBehaviour
{
    [SerializeField] private PorteriaController porteria;
    [SerializeField] private GameObject pelota;
    private Animator pelotaAnimator;
    private Vector3 originPosPelota;
    private Vector3 pelotaTarget;
    public float pelotaSpeed = 20f;
    public AudioClip chutar;

    [HideInInspector] public bool hasShot;

    private AudioSource audioSource;

    private void Start()
    {
        pelotaAnimator = pelota.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        originPosPelota = pelota.transform.position;
        pelotaTarget = originPosPelota;

        hasShot = false;
    }
    private void FixedUpdate()
    {
        pelota.transform.position = Vector3.MoveTowards(pelota.transform.position, pelotaTarget, pelotaSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Esta funcion la he creado para evitar un bug que ocurr�a a veces
    /// Era que si parabas y hab�as llegado un poco justo pues la pelota segu�a avanzando
    /// Por lo que se sumaba una parada y un gol
    /// </summary>
    public void StopPelota()
    {
        pelotaTarget = pelota.transform.position;
        pelotaAnimator.SetBool("chute", false);
        pelota.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void Shoot()
    {
        audioSource.PlayOneShot(chutar);
        pelotaTarget = porteria.RandPosToShoot().transform.position;
        Debug.Log("tornado de fuego a " + pelotaTarget);

        if (pelotaTarget.x > 0) {
            if (pelotaTarget.y > 0)
                pelota.transform.rotation = Quaternion.Euler(0, 0, -35);
            else
                pelota.transform.rotation = Quaternion.Euler(0, 0, -70);
        }
        else {
            if (pelotaTarget.y > 0)
                pelota.transform.rotation = Quaternion.Euler(0, 0, 35);
            else
                pelota.transform.rotation = Quaternion.Euler(0, 0, 70);
        }

        pelotaAnimator.SetBool("chute", true);

        hasShot = true;
    }

    public void ResetShot()
    {
        pelotaAnimator.SetBool("chute", false);
        pelota.transform.rotation = Quaternion.Euler(0, 0, 0);
        pelota.transform.position = originPosPelota;
        pelotaTarget = originPosPelota;

        hasShot = false;
    }

}
