using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionPromptUI : MonoBehaviour
{
    private Camera _mainCamera;
    [SerializeField] TextMeshProUGUI _promtText;
    [SerializeField] GameObject _uiPanel;
    [SerializeField] GameObject bookPanel;

    private void Start()
    {
        _mainCamera = Camera.main;
        _uiPanel.SetActive(false);
    }
    private void LateUpdate()
    {
        var rotation = _mainCamera.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
    }

    public bool isDisplayed = false;

    public void SetUp(string promptText)
    {
        _promtText.text = promptText;   
        _uiPanel.SetActive(true); 
        isDisplayed = true; 
    }
    
    public void Close()
    {
        isDisplayed= false;
        _uiPanel.SetActive(false);
    }

}
