using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    public string SceneName;

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
        SceneManager.LoadScene(SceneName);
    }

    public void CerrarJuego()
    {
        Application.Quit();
        Debug.Log("Salir");
    }

}
