using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [Header("Painéis de pause")]
    public GameObject pauseMenu;
    public GameObject controles;
    public GameObject som;
    public bool isPaused;

    [Header("Buttons")]
    public GameObject bttns;

    [Header("Som")]
    public Slider _musicSlider;
    public Slider _sfxSlider;

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Tecla P pressionada");
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Manager.instance.ToggleInteracting(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        Manager.instance.ToggleInteracting(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ControlesPanel()
    {
        bttns.SetActive(false);
        controles.SetActive(true);
    }

    public void SomPanel()
    {
        bttns.SetActive(false);
        som.SetActive(true);
    }
    public void VoltarAoPause()
    {
        controles.SetActive(false);
        som.SetActive(false);
        bttns.SetActive(true);
    }

    public void MenuPrincipal()
    {
        SceneManager.LoadScene(0);
    }

    public void ToggleMusic()
    {
        AudioManager.instance.ToggleMusic();
    }
    public void ToggleSFX()
    {
        AudioManager.instance.ToggleSFX();
    }

    public void MusicVolume()
    {
        AudioManager.instance.MusicVolume(_musicSlider.value);
    }

    public void SFXVolume()
    {
        AudioManager.instance.SFXVolume(_sfxSlider.value);
    }
}
