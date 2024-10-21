using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausarManager : MonoBehaviour
{
    public GameObject[] arrowsPauseMenu;
    public GameObject[] arrowsOptionsMenu;
    public GameObject[] arrowsCertezaMenu;
    public GameObject[] arrowsGameOverMenu;
    public GameObject[] arrowsControles;

    [SerializeField] private string nomeDoMenu;
    [SerializeField] private GameObject painelPause;
    [SerializeField] private GameObject painelOpcoes;
    [SerializeField] private GameObject painelCerteza;
    [SerializeField] private GameObject painelCerteza2;
    [SerializeField] private GameObject painelGameOver;
    [SerializeField] private GameObject painelControles;
    [SerializeField] private GameObject nomezinho;
    [SerializeField] private GameObject nomezinho2;
    [SerializeField] private GameObject nomezinho3;
    [SerializeField] private GameObject canva;
    [SerializeField] private GameObject canva2;
    // [SerializeField] private GameObject camera;
    private bool isPaused = false;

    
    void Update()

    {
    
     // INSTANCIA PRO GAME OVER
     
     /* if (                    )
        {
            // Se o Canvas estiver desativado, ativa ele
            if (!canva2.activeSelf)
            {
                canva2.SetActive(true);
            }
            // Se o Canvas estiver ativado, desativa ele
            else if (canva2.activeSelf)
            {
                canva2.SetActive(false);
            } 
     */

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

                if (isPaused)
                {
                    // camera.SetActive(true);
                    DisableArrows(arrowsPauseMenu);
                    ResumeGame();
                }
                else
                {
                    // camera.SetActive(false);
                    PauseGame(); 
                }
            }
        

        if (!painelOpcoes.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                {   
                    painelPause.SetActive(true);
                    DisableArrows(arrowsOptionsMenu);
                    painelOpcoes.SetActive(false);
                    nomezinho.SetActive(true);
                }
            }
        }
    }

       void PauseGame()
    {
        Time.timeScale = 0;  // Pausa o tempo
        isPaused = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
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

    public void GameOver()

    {
        Time.timeScale = 1;
        isPaused = false;
        // camera.SetActive(true); 
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void SairGameOver()
    {
        DisableArrows(arrowsGameOverMenu);
        painelGameOver.SetActive(false);
        nomezinho2.SetActive(false);
        painelCerteza2.SetActive(true);
    }
    public void SairMenu()
    {
        DisableArrows(arrowsPauseMenu);
        painelPause.SetActive(false);
        nomezinho.SetActive(false);
        painelCerteza.SetActive(true);
    }

    public void FecharCerteza2()
    {
        DisableArrows(arrowsCertezaMenu);
        painelCerteza2.SetActive(false);
        painelGameOver.SetActive(true);
        nomezinho2.SetActive(true);
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
        DisableArrows(arrowsPauseMenu);
        Time.timeScale = 1;
        isPaused = false;
        //camera.SetActive(true); 
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        canva.SetActive(false);
    }

    public void AbrirControles()
    {
        DisableArrows(arrowsOptionsMenu);
        painelOpcoes.SetActive(false);
        painelControles.SetActive(true);
        nomezinho3.SetActive(true);
    }

    public void FecharControles()
    {
        DisableArrows(arrowsControles);
        painelControles.SetActive(false);
        painelOpcoes.SetActive(true);
        // nomezinho.SetActive(true);
    }

    public void Quit()
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

