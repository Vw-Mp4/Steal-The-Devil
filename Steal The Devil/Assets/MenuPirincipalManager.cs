using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPirincipalManager : MonoBehaviour


{
    public GameObject[] arrowsMainMenu;
    public GameObject[] arrowsOptionsMenu;

    [SerializeField] private string nomeDoLeveLDeJogo;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;
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
        Application.Quit();
    }

    private void DisableArrows(GameObject[] arrows)
    {
        foreach (GameObject arrow in arrows)
        {
            arrow.SetActive(false);
        }
    }
}
