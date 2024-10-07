using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Serve pra conseguir carregar a outra cena quando der play

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] private string NomeDoJogo;
    [SerializeField] private GameObject AbaMenuPrincipal;
    [SerializeField] private GameObject AbaOpcoes;

    [SerializeField] private GameObject[] arrowsMainMenu; // Array para as setas do menu principal
    [SerializeField] private GameObject[] arrowsOptionsMenu; // Array para as setas do menu de opções

    public void Play()
    {
        SceneManager.LoadScene(NomeDoJogo);
    }   

    public void OpenSettings()
    {
        AbaMenuPrincipal.SetActive(false);
        AbaOpcoes.SetActive(true);

        // Desativa as setas do menu principal
        DisableArrows(arrowsMainMenu);
    }

    public void CloseSettings()
    {
        AbaMenuPrincipal.SetActive(true);
        AbaOpcoes.SetActive(false);

        // Desativa as setas do menu de opções
        DisableArrows(arrowsOptionsMenu);
    }

    public void QuitGame()
    {
        Application.Quit(); 
    }

    // Método para desativar todas as setas
    private void DisableArrows(GameObject[] arrows)
    {
        foreach (GameObject arrow in arrows)
        {
            arrow.SetActive(false); // Desativa cada seta
        }
    }

    
}
