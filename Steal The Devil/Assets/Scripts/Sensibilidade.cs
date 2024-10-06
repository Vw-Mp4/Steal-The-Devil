using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensibilidade : MonoBehaviour
{
    public static Sensibilidade instance;

    [SerializeField] private Slider sensitivitySlider;
    private float mouseSensitivity;

    void Awake()
    {
        // Verifica se já existe uma instância deste objeto
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Faz o objeto persistir entre cenas
        }
        else
        {
            Destroy(gameObject); // Destroi duplicatas do objeto
        }
    }

    void Start()
    {
        // Inicializa a sensibilidade com o valor do slider
        mouseSensitivity = sensitivitySlider.value;

        // Adiciona um listener ao slider para detectar mudanças no valor
        sensitivitySlider.onValueChanged.AddListener(OnSensitivityChanged);
    }

    void OnSensitivityChanged(float newSensitivity)
    {
        // Atualiza a sensibilidade do mouse quando o slider for ajustado
        mouseSensitivity = newSensitivity;
    }

    // Método para obter a sensibilidade atual (caso precise em outros scripts)
    public float GetMouseSensitivity()
    {
        return mouseSensitivity;
    }
}
