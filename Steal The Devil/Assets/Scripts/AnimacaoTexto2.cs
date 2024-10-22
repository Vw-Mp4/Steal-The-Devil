using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AnimacaoTexto2 : MonoBehaviour
{
    public RectTransform textRectTransform; // referência ao RectTransform do texto
    private Vector2 initialPosition; // posição inicial do texto
    public Vector2 targetPosition = new Vector2(276.6f, 160.7f); // posição que eu quero no final
    public float duration = 1.0f; // duração da animação
    private bool isMoving = false;

    void Start()
    {
        // salva a posição inicial
        initialPosition = textRectTransform.anchoredPosition;
    }

    void Update()
    {
        // tem q botar os parametros aqui
        if (Input.GetKeyDown(KeyCode.K) && !isMoving)
        {
            StartCoroutine(MoveTextSmoothly(targetPosition, duration));
        }
    }

    IEnumerator MoveTextSmoothly(Vector2 targetPos, float moveDuration)
    {
        isMoving = true;

        // posição inicial da animação
        Vector2 startPos = textRectTransform.anchoredPosition;
        float elapsedTime = 0;

        // move o texto 'gradualmente' até a posição alvo
        while (elapsedTime < moveDuration)
        {
            textRectTransform.anchoredPosition = Vector2.Lerp(startPos, targetPos, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // garante que a posição final seja Exatamente a posição alvo
        textRectTransform.anchoredPosition = targetPos;

        // espera por uns 4 segundos
        yield return new WaitForSeconds(4);

        // move o texto de volta para a posição inicial de forma SUAVE
        elapsedTime = 0;
        while (elapsedTime < moveDuration)
        {
            textRectTransform.anchoredPosition = Vector2.Lerp(targetPos, initialPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // garante que a posição final seja exatamente a posição inicial
        textRectTransform.anchoredPosition = initialPosition;

        isMoving = false;
    }
}