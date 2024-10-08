using UnityEngine;
using UnityEngine.EventSystems; // só pra usar IPointerEnterHandler e IPointerExitHandler

public class Seta : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject arrow; 

    // quando o mouse entra no botão
    public void OnPointerEnter(PointerEventData eventData)
    {
        arrow.SetActive(true); // Ativa a seta
    }

    // quando o mouse sai do botão
    public void OnPointerExit(PointerEventData eventData)
    {
        arrow.SetActive(false);
    }
}
