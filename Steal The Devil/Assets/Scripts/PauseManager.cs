using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject[] arrowsPauseMenu;
    public GameObject[] arrowsOptionsMenu;
    public GameObject[] arrowsCertezaMenu;

    [SerializeField] private string nomeDoMenu;
    [SerializeField] private GameObject painelPause;
    [SerializeField] private GameObject painelOpcoes;
    [SerializeField] private GameObject painelCerteza;
    [SerializeField] private GameObject nomezinho;
    [SerializeField] private GameObject canva;

    
    void Update()

    {
    if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Se o Canvas estiver desativado, ativa ele
            if (!canva.activeSelf)
            {
                canva.SetActive(true);
            }
            // Se o Canvas estiver ativado, desativa ele
            else if (canva.activeSelf)
            {
                canva.SetActive(false);
            }
        }
    }

    public void Sair()
    {
        SceneManager.LoadScene(nomeDoMenu);
    }

    public void AbrirOptions()
    {
        DisableArrows(arrowsPauseMenu);
        painelPause.SetActive(false);
        nomezinho.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void FecharOptions()
    {
        DisableArrows(arrowsOptionsMenu);
        painelOpcoes.SetActive(false);
        nomezinho.SetActive(true);
        painelPause.SetActive(true);
    }

    public void SairMenu()
    {
        DisableArrows(arrowsPauseMenu);
        painelPause.SetActive(false);
        nomezinho.SetActive(false);
        painelCerteza.SetActive(true);
    }

    public void FecharCerteza()
    {
        DisableArrows(arrowsCertezaMenu);
        painelCerteza.SetActive(false);
        painelPause.SetActive(true);
        nomezinho.SetActive(true);
    }

    public void Resume()
    {
        canva.SetActive(false);
    }

    private void DisableArrows(GameObject[] arrows)
    {
        foreach (GameObject arrow in arrows)
        {
            arrow.SetActive(false);
        }
    }
    
}
