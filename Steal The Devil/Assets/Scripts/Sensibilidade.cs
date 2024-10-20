using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class Sensibilidade : MonoBehaviour
{
    public Slider sensitivitySlider;  // Referência ao slider
    public CinemachineVirtualCamera virtualCamera;  // Referência à Cinemachine Virtual Camera
    public Transform cameraTarget; // O alvo que a câmera segue (ou o objeto que está rotacionando com o mouse)
    public float sensitivity = 4.0f; // Sensibilidade inicial do mouse

    private float mouseX, mouseY;

    void Start()
    {
        // Definindo o valor inicial do slider como a sensibilidade atual
        sensitivitySlider.value = sensitivity;

        // Adiciona um listener para ajustar a sensibilidade conforme o slider for alterado
        sensitivitySlider.onValueChanged.AddListener(AdjustSensitivity);
    }

    void Update()
    {
        // Obtém as entradas do mouse
        mouseX = Input.GetAxis("Mouse X") * sensitivity;
        mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Rotaciona o alvo da câmera (target), que a Cinemachine segue
        cameraTarget.Rotate(Vector3.up, mouseX); // Rotação horizontal
        cameraTarget.Rotate(Vector3.right, -mouseY); // Rotação vertical (invertida para dar efeito de controle natural)
    }

    // Função para ajustar a sensibilidade com base no valor do slider
    public void AdjustSensitivity(float newSensitivity)
    {
        sensitivity = newSensitivity;
    }
}