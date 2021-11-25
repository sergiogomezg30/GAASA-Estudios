using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteriaController : MonoBehaviour
{
    private List<DisparoController> posiblesDisparos;

    [SerializeField] private GameObject portero;
    public float porteroSpeed = 2f;
    private bool clicked;
    private Vector3 porteroTarget;
    private Vector3 originPosPortero;

    [SerializeField] private ThinkFutbol ninoQueDispara;
    private float incrementoSpeed = 0.75f;

    private int goles, paradas;
    private float tiempoEntreRondas;

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
        tiempoEntreRondas = 2f;

        UIMinijuegoFutbolSystem.Instance.SetGolesUI(goles);
        UIMinijuegoFutbolSystem.Instance.SetParadasUI(paradas);
    }

    /////////////////////////////////////////////////////
    //EL UPDATE ES PARA TESTEAR, LUEGO HAY QUE BORRARLO//
    /////////////////////////////////////////////////////
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

    IEnumerator AnotherRound(bool parada)
    {
        UIMinijuegoFutbolSystem.Instance.Celebrar(parada);
        yield return new WaitForSeconds(tiempoEntreRondas);

        if (parada) {   //si has parada pues el siguiente disparo va más rápido
            ninoQueDispara.pelotaSpeed += incrementoSpeed;
        }
        else {
            ninoQueDispara.pelotaSpeed -= incrementoSpeed / 2;  //no se reduce tan rapido para que sea más dificil
        }
        Debug.Log("la pelota va a ir a " + ninoQueDispara.pelotaSpeed);
        ResetAll();

        yield return new WaitForSeconds(0.5f);  //dar un pequeño margen de tiempo para reaccionar y disparar
        ninoQueDispara.Shoot();
    }

    private void ResetAll()
    {
        ninoQueDispara.ResetShot();

        portero.transform.position = originPosPortero;
        porteroTarget = originPosPortero;

        clicked = false;

        UIMinijuegoFutbolSystem.Instance.FinCelebracion();
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
        UIMinijuegoFutbolSystem.Instance.SetGolesUI(goles);

        StartCoroutine(AnotherRound(false));
    }

    public void ParadaDelPlayer()
    {
        paradas++;
        UIMinijuegoFutbolSystem.Instance.SetParadasUI(paradas);

        ninoQueDispara.StopPelota();
        StartCoroutine(AnotherRound(true));
    }
}
