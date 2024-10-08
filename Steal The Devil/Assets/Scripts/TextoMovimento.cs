using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonTextMove : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private RectTransform botaoTextRectTransform;
    [SerializeField] private RectTransform setaRectTransform;  
    [SerializeField] private float moveDistance = 5f; //distância que o texto vai se mover

    private Vector3 botaooriginalPosition;
    private Vector3 setaoriginalPosition;

    void Start()
    {
        // "salva" a posição original do texto e da seta
        botaooriginalPosition = botaoTextRectTransform.localPosition;
        setaoriginalPosition = setaRectTransform.localPosition;
    }

    // quando o botão é pressionado
    public void OnPointerDown(PointerEventData eventData)
    {
        // move o texto para baixo
        botaoTextRectTransform.localPosition = botaooriginalPosition - new Vector3(0, moveDistance, 0);
        setaRectTransform.localPosition = setaoriginalPosition - new Vector3(0, moveDistance, 0);
    }

    // quando o botão é solto
    public void OnPointerUp(PointerEventData eventData)
    {
        botaoTextRectTransform.localPosition = botaooriginalPosition;
        setaRectTransform.localPosition = setaoriginalPosition;
    }
}