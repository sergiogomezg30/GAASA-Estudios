using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToGame3 : MonoBehaviour
{
    public Animator fundidoNegro;
    public float aumento = 0.15f;
    public string nombreJuego;

    //Pequeño pop para resaltar que el objeto es interactuable
    void OnMouseEnter()
    {
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
        StartCoroutine(CambioEscena());

    }

    IEnumerator CambioEscena()
    {

        yield return new WaitForSeconds(1);
        fundidoNegro.SetTrigger("transicion");

        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nombreJuego);

    }
}

