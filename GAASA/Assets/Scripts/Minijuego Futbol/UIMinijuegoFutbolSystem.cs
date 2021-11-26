using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMinijuegoFutbolSystem : MonoBehaviour
{
    public static UIMinijuegoFutbolSystem Instance;

    [SerializeField] private Text paradasText;
    [SerializeField] private Transform paradasImages;
    [SerializeField] private Text golesText;
    [SerializeField] private Transform golesImages;

    [SerializeField] private Image celebracionImage;
    [SerializeField] private Sprite[] imagenes; //[0] es la de parada y [1] es la de gol
    private RectTransform celebracionRT;
    //private Vector2 originRTsize;
    private int originHeightWidth;

    void Awake()
    {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        }
        else {
            Instance = this;
        }

        celebracionRT = celebracionImage.gameObject.GetComponent<RectTransform>();
        //originRTsize = celebracionRT.sizeDelta;
        originHeightWidth = 200;
    }

    private void Start()
    {
        //apagar las imagenes de paradas y goles
        RestartUI();

        //que de primeras la imagen de celeracion esté apagada
        FinCelebracion();
    }

    public void SetParadasUI(int paradas)
    {
        paradasText.text = "Paradas: " + paradas;
        paradasImages.GetChild(paradas - 1).gameObject.SetActive(true);
    }

    public void SetGolesUI(int goles)
    {
        golesText.text = "Goles: " + goles;
        golesImages.GetChild(goles - 1).gameObject.SetActive(true);
    }

    public void Celebrar(bool parada)
    {
        celebracionImage.enabled = true;

        float relation;

        if (parada) {
            celebracionImage.sprite = imagenes[0];
            relation = imagenes[0].rect.height / imagenes[0].rect.width;
            celebracionRT.sizeDelta = new Vector2(originHeightWidth, relation * originHeightWidth);     //poner a la resolucion bien (escalado)

            LeanTween.size(celebracionRT, new Vector2(celebracionRT.sizeDelta.x * 1.5f, celebracionRT.sizeDelta.y * 1.5f), 0.25f).setOnComplete(ReajustarScaleRT);
        }
        else {
            celebracionImage.sprite = imagenes[1];
            relation = imagenes[1].rect.height / imagenes[1].rect.width;
            celebracionRT.sizeDelta = new Vector2(originHeightWidth, relation * originHeightWidth);     //poner a la resolucion bien (escalado)

            LeanTween.move(celebracionRT, new Vector3(0f, -25f, 0f), 0.5f).setOnComplete(BoingCaida);
        }
    }

    //simplemente están para llamar al tween sin errores
    private void ReajustarScaleRT()
    {
        LeanTween.size(celebracionRT, new Vector2(originHeightWidth, imagenes[0].rect.height / imagenes[0].rect.width * originHeightWidth), 0.25f);
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

    /// <summary>
    /// NO LLAMAR A ESTA FUNCION DESDE NINGUN LADO
    /// ESTA public PARA TESTING
    /// </summary>
    public void RestartUI()
    {
        for (int i = 0; i < paradasImages.childCount; i++)
        {
            paradasImages.GetChild(i).gameObject.SetActive(false);
        }
        for (int i = 0; i < golesImages.childCount; i++)
        {
            golesImages.GetChild(i).gameObject.SetActive(false);
        }
    }
}
