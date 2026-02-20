using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject menuPausa;
    private bool paused=false;
    public void Pause(InputAction.CallbackContext context)
    {
        if (paused)
        {
            Reanudar();
        }
        else
        {
            Pausar();
        }

    }

    private void Pausar()
    {
        menuPausa.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void Reanudar()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1.0f;
        paused = false;
    }

    public void Menu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Menu");
    }
}
