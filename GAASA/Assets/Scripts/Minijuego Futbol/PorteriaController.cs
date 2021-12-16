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
    private float incrementoSpeed = 1.25f;
    private string nombreNinoQueDispara = "Daniel";

    private int goles, paradas;
    private float tiempoEntreRondas;

    [SerializeField] private UnityEngine.UI.Button buttonVolverJugar; 

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

        buttonVolverJugar.onClick.AddListener(Restart);

        StartJugarFutbol();
    }

    /////////////////////////////////////////////////////
    //EL UPDATE ES PARA TESTEAR, LUEGO HAY QUE BORRARLO//
    /////////////////////////////////////////////////////
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
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

        if (paradas >= 8 || goles >= 8) {   //hemos ganado o perdido
            FinFutbol();
        }
        else {                              //seguimos jugando
            ninoQueDispara.Shoot();
        }
    }

    private void StartJugarFutbol()
    {
        GameEvents.Instance.onFinishDialogue += PrimerDisparo;
        DialogueSystem.Instance.AddNewDialogue(new string[] { "Yo disparo y tú me paras", "Si marco 8 te he ganado", "Y si me paras 8 ganas tú" },
                                                                    nombreNinoQueDispara,
                                                                    ninoQueDispara.gameObject.GetComponent<SpriteRenderer>(),
                                                                    true);
    }

    public void RemovePrimerDisparo()
    {
        GameEvents.Instance.onFinishDialogue -= PrimerDisparo;
    }

    #region Evento PrimerDisparo
    private void PrimerDisparo()
    {
        StartCoroutine(Empezando());
        GameEvents.Instance.onFinishDialogue -= PrimerDisparo;
    }
    IEnumerator Empezando()
    {
        //poner aqui el pop del "A JUGAR"

        yield return new WaitForSeconds(2f);

        ninoQueDispara.Shoot();     //despues de aparecer el pop se empieza a jugar
    }
    #endregion

    private void ResetAll()
    {
        ninoQueDispara.ResetShot();

        portero.transform.position = originPosPortero;
        porteroTarget = originPosPortero;

        clicked = false;

        UIMinijuegoFutbolSystem.Instance.FinCelebracion();
    }

    private void Restart()
    {
        UIMinijuegoFutbolSystem.Instance.RestartUI();
        goles = 0;
        paradas = 0;
        //ninoQueDispara.pelotaSpeed += -(paradas * incrementoSpeed) + (goles * incrementoSpeed / 2);
        ninoQueDispara.pelotaSpeed = 10;
        ResetAll();

        PrimerDisparo();
    }

    private void FinFutbol()
    {
        GameEvents.Instance.onFinishDialogue += (() => UIMinijuegoFutbolSystem.Instance.panelSeguirJugando.SetActive(true));

        if (paradas >= 8) { //hemos ganado parando
            DialogueSystem.Instance.AddNewDialogue(new string[] { "¡Jobar!", "Pues al final sí que eres buen portero", "¿Revancha?" },
                                                                    nombreNinoQueDispara,
                                                                    ninoQueDispara.gameObject.GetComponent<SpriteRenderer>(),
                                                                    true);
        }
        else {  //hemos perdido y lo hemos llamada por los goles
            DialogueSystem.Instance.AddNewDialogue(new string[] { "¡Te he ganado!", "Me ha gustado jugar contigo", "Te dejo otro intento si quieres jeje" },
                                                                    nombreNinoQueDispara,
                                                                    ninoQueDispara.gameObject.GetComponent<SpriteRenderer>(),
                                                                    true);
        }
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
