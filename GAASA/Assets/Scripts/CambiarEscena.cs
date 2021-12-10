using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    public string SceneName;
    public float tiempo = 2.1f;

    private void Start()
    {
        //para testear, a lo mejor los datos hay que cambiarlos
        FinalDiaData.diaActual = 1;
        FinalDiaData.ahorrosMoney = 1000;
        FinalDiaData.cocheArreglado = true;
        ///////////////////////////////////////////////////////////////////
    }

    public void LoadScene()
    {
        StartCoroutine(EmpezarDia(tiempo));
    }

    public void CerrarJuego()
    {
        Application.Quit();
        Debug.Log("Salir");
    }

    IEnumerator EmpezarDia(float segundos)
    {
        yield return new WaitForSeconds(tiempo);
        SceneManager.LoadScene(SceneName);
    }

}
