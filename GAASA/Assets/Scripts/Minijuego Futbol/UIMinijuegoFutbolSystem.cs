using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMinijuegoFutbolSystem : MonoBehaviour
{
    public static UIMinijuegoFutbolSystem Instance;

    [SerializeField] private Text paradasText;
    [SerializeField] private Text golesText;

    [SerializeField] private Image celebracionImage;
    [SerializeField] private Sprite[] imagenes; //[0] es la de parada y [1] es la de gol
    private RectTransform celebracionRT;
    private Vector2 originRTsize;

    void Awake()
    {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        }
        else {
            Instance = this;
        }

        celebracionRT = celebracionImage.gameObject.GetComponent<RectTransform>();
        originRTsize = celebracionRT.sizeDelta;
    }

    private void Start()
    {
        FinCelebracion();   //que de primeras la imagen esté apagada
    }

    public void SetGolesUI(int goles)
    {
        golesText.text = "Goles: " + goles;
    }

    public void SetParadasUI(int paradas)
    {
        paradasText.text = "Paradas: " + paradas;
    }

    public void Celebrar(bool parada)
    {
        celebracionImage.enabled = true;

        if (parada) {
            celebracionImage.sprite = imagenes[0];
            LeanTween.size(celebracionRT, new Vector2(originRTsize.x * 1.5f, originRTsize.y * 1.5f), 0.25f).setOnComplete(ReajustarScaleRT);
        }
        else {
            celebracionImage.sprite = imagenes[1];
            LeanTween.move(celebracionRT, new Vector3(0f, -25f, 0f), 0.5f).setOnComplete(BoingCaida);
        }
    }

    //simplemente están para llamar al tween sin errores
    private void ReajustarScaleRT()
    {
        LeanTween.size(celebracionRT, new Vector2(originRTsize.x, originRTsize.y), 0.25f);
    }
    private void BoingCaida()
    {
        LeanTween.move(celebracionRT, new Vector3(0f, -12.5f, 0f), 0.25f);
    }

    public void FinCelebracion()
    {
        celebracionRT.anchoredPosition = new Vector3(0f, 0f, 0f);
        celebracionImage.enabled = false;
    }
}
