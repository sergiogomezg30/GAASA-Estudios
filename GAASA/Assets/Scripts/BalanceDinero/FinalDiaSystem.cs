using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalDiaSystem : MonoBehaviour
{
    [SerializeField] private GameObject uiBalanceDineroFinalDia;

    [SerializeField] private BaseDia[] dias;   //un array para almacenar todos los dias de la semana e ir usandolos
    private int posDiaActual;

    [SerializeField] private TextMeshProUGUI numeroDia;
    [SerializeField] private TextMeshProUGUI descripcionDia;

    [SerializeField] private TextMeshProUGUI ahorrosCant;
    [SerializeField] private TextMeshProUGUI comidasCant;

    [SerializeField] private Transform gastosVariablesTextContainer;
    private TextMeshProUGUI[] gastosVariablesText;

    [SerializeField] private Transform gastosVariablesCantContainer;
    private TextMeshProUGUI[] gastosVariablesCant;
    private MyButton[] botonElegirGasto;

    [SerializeField] private TextMeshProUGUI dineroRestanteCant;

    void Start()
    {        
        posDiaActual = FinalDiaData.diaActual - 1;

        numeroDia.text = "Final Día " + dias[posDiaActual].dia.ToString();
        descripcionDia.text = dias[posDiaActual].descriptionDia;

        ahorrosCant.text = FinalDiaData.ahorrosMoney.ToString();
        comidasCant.text = (-FinalDiaData.gastosComida).ToString();

        //declarar izquierda del panel de gastos
        gastosVariablesText = new TextMeshProUGUI[gastosVariablesTextContainer.childCount];
        for (int i = 0; i < gastosVariablesTextContainer.childCount; i++) {
            gastosVariablesText[i] = gastosVariablesTextContainer.GetChild(i).GetComponent<TextMeshProUGUI>();
        }

        //declarar derecha del panel de gastos
        gastosVariablesCant = new TextMeshProUGUI[gastosVariablesCantContainer.childCount];
        botonElegirGasto = new MyButton[gastosVariablesCantContainer.childCount];

        for (int i = 0; i < gastosVariablesCantContainer.childCount; i++) {
            gastosVariablesCant[i] = gastosVariablesCantContainer.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>();

            botonElegirGasto[i] = gastosVariablesCantContainer.GetChild(i).GetChild(1).GetComponent<MyButton>();
            botonElegirGasto[i].gameObject.SetActive(false);    //apagar los botones y ya ver luego si se necesitan
        }

        //declarar gastosExtras del dia
        //la unica forma que se me ocurria de hacer esto era hardcode :(
        BaseDia diaActual = dias[posDiaActual];
        switch (dias[posDiaActual].dia) {
            case 1:
                //primero encender gameObjects que quiero usar, luego colocar bien en el canvas pero aqui no ha hecho falta
                gastosVariablesText[0].gameObject.SetActive(true);
                gastosVariablesCant[0].transform.parent.gameObject.SetActive(true); //se podría poner tambien con botonElegirGasto[0]

                //poner textos como quiero
                gastosVariablesText[0].text = diaActual.gastosExtras[0].nombreGasto;
                gastosVariablesCant[0].text = (-diaActual.gastosExtras[0].coste).ToString();
                
                //activar boton
                if (diaActual.gastosExtras[0].esOpcional) {
                    botonElegirGasto[0].gameObject.SetActive(true);
                    botonElegirGasto[0].buttonClick.AddListener(SetCocheArreglado);
                }
                break;

            case 2:
                if (!FinalDiaData.cocheArreglado) {  //si no está arreglado tenemos que poner el precio del coche ahora
                    //gasto del coche sin opcion
                    gastosVariablesText[0].gameObject.SetActive(true);
                    gastosVariablesCant[0].transform.parent.gameObject.SetActive(true);

                    gastosVariablesText[0].text = diaActual.gastosExtras[0].nombreGasto;
                    gastosVariablesCant[0].text = (-diaActual.gastosExtras[0].coste).ToString();

                    //gastos medicos
                    gastosVariablesText[1].gameObject.SetActive(true);
                    gastosVariablesCant[1].transform.parent.gameObject.SetActive(true);

                    gastosVariablesText[1].text = diaActual.gastosExtras[2].nombreGasto;    //gastos fuertes porque no hemos ido en coche
                    gastosVariablesCant[1].text = (-diaActual.gastosExtras[2].coste).ToString();
                }
                else {
                    //gastos medicos solo
                    gastosVariablesText[0].gameObject.SetActive(true);
                    gastosVariablesCant[0].transform.parent.gameObject.SetActive(true);

                    gastosVariablesText[0].text = diaActual.gastosExtras[1].nombreGasto;
                    gastosVariablesCant[0].text = (-diaActual.gastosExtras[1].coste).ToString();
                }
                break;

            default:
                Debug.LogError("Este día no está implementado en los 'case' del codigo!!");
                break;
        }

        CalculateDineroRestante();
        uiBalanceDineroFinalDia.SetActive(false);
    }

    /// <summary>
    /// Las posiciones de los array son hardcode
    /// no se me ocurria otra forma :(
    /// </summary>
    private void SetCocheArreglado()
    {
        FinalDiaData.cocheArreglado = !FinalDiaData.cocheArreglado;

        if (!FinalDiaData.cocheArreglado) {
            gastosVariablesText[0].fontStyle = FontStyles.Strikethrough;
            gastosVariablesCant[0].fontStyle = FontStyles.Strikethrough;
        }
        else {
            gastosVariablesText[0].fontStyle = FontStyles.Normal;
            gastosVariablesCant[0].fontStyle = FontStyles.Normal;
        }

        CalculateDineroRestante();
    }

    private void CalculateDineroRestante()
    {
        int dineroRestante;

        dineroRestante = Convert.ToInt32(ahorrosCant.text) + Convert.ToInt32(comidasCant.text);
        
        for (int i = 0; i < gastosVariablesCant.Length; i++) {
            //si el container que los tiene está encendido es que lo estamos usando
            if (gastosVariablesCant[i].transform.parent.gameObject.activeSelf) {
                dineroRestante += Convert.ToInt32(gastosVariablesCant[i].text);
            }
        }

        //esto solo se ejecuta si tenemos el boton para activar y desactivar, es decir, el primer dia
        if (FinalDiaData.diaActual == 1 && !FinalDiaData.cocheArreglado)
            dineroRestante += dias[posDiaActual].gastosExtras[0].coste; //lo sumamos ya que es eso que se ahorra

        dineroRestanteCant.text = dineroRestante.ToString();
    }

    public void LoadNextDay()
    {
        SceneManager.LoadScene(dias[posDiaActual].nextDiaScene);
    }

    public void ShowFinalDayUI()
    {
        uiBalanceDineroFinalDia.SetActive(true);
    }
}
