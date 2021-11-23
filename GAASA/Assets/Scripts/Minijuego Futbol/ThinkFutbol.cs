using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThinkFutbol : MonoBehaviour
{
    [SerializeField] private PorteriaController porteria;
    [SerializeField] private GameObject pelota;
    private float pelotaSpeed = 1f;
    private Vector3 pelotaTarget;

    private void Start()
    {
        pelotaTarget = pelota.transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) {
            Shoot();
        }
    }

    public void Shoot()
    {
        pelotaTarget = porteria.RandPosToShoot().transform.position;
        Debug.Log("tornado de fuego a " + pelotaTarget);
    }

    private void FixedUpdate()
    {
        pelota.transform.position = Vector3.MoveTowards(pelota.transform.position, pelotaTarget, pelotaSpeed * Time.deltaTime);
    }
}
