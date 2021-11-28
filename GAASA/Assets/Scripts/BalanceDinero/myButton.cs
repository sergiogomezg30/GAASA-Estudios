using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MyButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private Sprite offSprite;
    [SerializeField] private Sprite highlightedSprite;
    [SerializeField] private Sprite pressedSprite;
    [SerializeField] private Sprite onSprite;

    private Image actualImage;
    private bool isOn;

    private void Start()
    {
        actualImage = GetComponent<Image>();
        isOn = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        isOn = !isOn;
        if (isOn)
            actualImage.sprite = onSprite;
        else
            actualImage.sprite = offSprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        actualImage.sprite = highlightedSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isOn)
            actualImage.sprite = onSprite;
        else
            actualImage.sprite = offSprite;

    }
}
