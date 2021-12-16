using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToGame : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject jugador;
    public Animator fundidoNegro;
    public Animator cocheAnim;
    public float aumento = 0.15f;
    public string nombreJuego;
    public AudioClip motorEncendido;
    public GameObject motor;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        motor.SetActive(false);
    }

    //Peque�o pop para resaltar que el objeto es interactuable
    void OnMouseEnter()
    {
        audioSource.PlayOneShot(motorEncendido);
        this.transform.localScale += new Vector3(aumento, aumento, 0);
    }

    void OnMouseExit()
    {
        this.transform.localScale -= new Vector3(aumento, aumento, 0);
    }

    void OnMouseDown()
    {
        motor.SetActive(true);
        //Si clickeas, se inicia una animacion.
        this.transform.localScale -= new Vector3(aumento, aumento, 0);

        cocheAnim.SetTrigger("empezar");
        //jugador.SetActive(false);
        jugador.GetComponent<SpriteRenderer>().enabled = false;
        jugador.GetComponent<controlPersonaje>().canMove = false;
        StartCoroutine(CambioEscena());

    }

    IEnumerator CambioEscena()
    {

        yield return new WaitForSeconds(4);
        fundidoNegro.SetTrigger("transicion");

        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nombreJuego);

    }
}
