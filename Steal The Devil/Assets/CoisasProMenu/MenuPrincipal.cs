using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Serve pra conseguir carregar a outra cena quando der play

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] private string NomeDoJogo; // [Serializefield] = Faz aparecer lá no inspector, nada de mais
    [SerializeField] private GameObject AbaMenuPrincipal;
    [SerializeField] private GameObject AbaOpcoes;

    public void Play()
    {
        SceneManager.LoadScene(NomeDoJogo);
    }   
    public void OpenSettings()
    {
        AbaMenuPrincipal.SetActive(false);
        AbaOpcoes.SetActive(true);
    }
    public void CLoseSettings()
    {
        AbaMenuPrincipal.SetActive(true);
        AbaOpcoes.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit(); // NOTA: Esse método não funciona no unity, mas só quando o jogo ter um executável
    }

}
