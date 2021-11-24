using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMinijuegoFutbolSystem : MonoBehaviour
{
    public static UIMinijuegoFutbolSystem Instance;

    [SerializeField] private Text paradasText;
    [SerializeField] private Text golesText;

    void Awake()
    {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        }
        else {
            Instance = this;
        }
    }

    public void SetGolesUI(int goles)
    {
        golesText.text = "Goles: " + goles;
    }

    public void SetParadasUI(int paradas)
    {
        paradasText.text = "Paradas: " + paradas;
    }
}
