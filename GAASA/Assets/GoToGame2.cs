using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToGame2 : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject jugador;
    public Animator fundidoNegro;
    public GameObject subirEscaleraAnim;
    public float aumento = 0.15f;
    public string nombreJuego;
    public AudioClip electricidad;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    //Peque�o pop para resaltar que el objeto es interactuable
    void OnMouseEnter()
    {
        audioSource.PlayOneShot(electricidad);
        this.transform.localScale += new Vector3(aumento, aumento, 0);
    }

    void OnMouseExit()
    {
        this.transform.localScale -= new Vector3(aumento, aumento, 0);
    }

    void OnMouseDown()
    {

        //Si clickeas, se inicia una animacion.
        this.transform.localScale -= new Vector3(aumento, aumento, 0);

        subirEscaleraAnim.SetActive(true);
        //jugador.SetActive(false);
        jugador.GetComponent<SpriteRenderer>().enabled = false;
        jugador.GetComponent<controlPersonaje>().canMove = false;
        StartCoroutine(CambioEscena());

    }

    IEnumerator CambioEscena()
    {

        yield return new WaitForSeconds(3);
        fundidoNegro.SetTrigger("transicion");

        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nombreJuego);

    }
}
