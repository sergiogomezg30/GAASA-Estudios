using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteriaController : MonoBehaviour
{
    private List<DisparoController> posiblesDisparos;

    [SerializeField] private GameObject portero;
    public float porteroSpeed = 1f;
    private bool clicked;
    private Vector3 porteroTarget;
    private Vector3 originPosPortero;

    [SerializeField] private ThinkFutbol ninoQueDispara;

    private int goles, paradas;

    void Start()
    {
        posiblesDisparos = new List<DisparoController>();
        //meter las posibles direcciones de disparo
        for (int i = 0; i < transform.childCount; i++) {
            posiblesDisparos.Add(transform.GetChild(i).GetComponent<DisparoController>());
        }

        clicked = false;
        originPosPortero = portero.transform.position;
        porteroTarget = originPosPortero;

        goles = 0;
        paradas = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            ninoQueDispara.Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetAll();
        }
    }

    private void FixedUpdate()
    {
        portero.transform.position = Vector3.MoveTowards(portero.transform.position, porteroTarget, porteroSpeed * Time.deltaTime);
    }

    private void ResetAll()
    {
        ninoQueDispara.ResetShot();

        portero.transform.position = originPosPortero;
        porteroTarget = originPosPortero;

        clicked = false;
    }

    public DisparoController RandPosToShoot()
    {
        return posiblesDisparos[Random.Range(0, posiblesDisparos.Count)];
    }

    public void PorteroPara(DisparoController disparoController)
    {
        //solo mover la 'x' y la 'y' y restar el fallo de altura
        if (!clicked && ninoQueDispara.hasShot) {
            porteroTarget = new Vector3(disparoController.transform.position.x, disparoController.transform.position.y - 2.72f, porteroTarget.z);
            clicked = true;
        }
    }

    public void GolDeLaIA()
    {
        goles++;
        Debug.Log("GOL!!!");
        Debug.Log("La IA ha metido " + goles + " goles");
    }

    public void ParadaDelPlayer()
    {
        paradas++;
        Debug.Log("Parada");
        Debug.Log("Llevas parados " + paradas + " chutes");
    }
}
