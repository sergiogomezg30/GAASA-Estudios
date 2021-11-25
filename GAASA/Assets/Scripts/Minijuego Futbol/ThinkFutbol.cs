using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThinkFutbol : MonoBehaviour
{
    [SerializeField] private PorteriaController porteria;
    [SerializeField] private GameObject pelota;
    private Vector3 originPosPelota;
    private Vector3 pelotaTarget;
    public float pelotaSpeed = 20f;

    [HideInInspector] public bool hasShot;

    private void Start()
    {
        originPosPelota = pelota.transform.position;
        pelotaTarget = originPosPelota;

        hasShot = false;
    }
    private void FixedUpdate()
    {
        pelota.transform.position = Vector3.MoveTowards(pelota.transform.position, pelotaTarget, pelotaSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Esta funcion la he creado para evitar un bug que ocurría a veces
    /// Era que si parabas y habías llegado un poco justo pues la pelota seguía avanzando
    /// Por lo que se sumaba una parada y un gol
    /// </summary>
    public void StopPelota()
    {
        pelotaTarget = pelota.transform.position;
    }

    public void Shoot()
    {
        pelotaTarget = porteria.RandPosToShoot().transform.position;
        Debug.Log("tornado de fuego a " + pelotaTarget);

        hasShot = true;
    }

    public void ResetShot()
    {
        pelota.transform.position = originPosPelota;
        pelotaTarget = originPosPelota;

        hasShot = false;
    }

}
