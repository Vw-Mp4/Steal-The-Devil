using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPirincipalManager : MonoBehaviour
{
    public GameObject[] arrowsMainMenu;
    public GameObject[] arrowsOptionsMenu;
    public GameObject[] arrowsCertezaMenu;

    [SerializeField] private string nomeDoLeveLDeJogo;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;
    [SerializeField] private GameObject painelCerteza;
    
    public void Jogar()
    {
        SceneManager.LoadScene(nomeDoLeveLDeJogo);
    }

    public void AbrirOpcoes()
    {
        DisableArrows(arrowsMainMenu);
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void FecharOpcoes()
    {
        DisableArrows(arrowsOptionsMenu);
        painelOpcoes.SetActive(false);
        painelMenuInicial.SetActive(true);
    }

    public void SairJogo()
    {
        DisableArrows(arrowsMainMenu);
        painelMenuInicial.SetActive(false);
        painelCerteza.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void FecharCerteza()
    {
        DisableArrows(arrowsCertezaMenu);
        painelCerteza.SetActive(false);
        painelMenuInicial.SetActive(true);
    }

    private void DisableArrows(GameObject[] arrows)
    {
        foreach (GameObject arrow in arrows)
        {
            arrow.SetActive(false);
        }
    }
}
