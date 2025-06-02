using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject PanelInfo;
    public GameObject PanelCred;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PanelInfo.SetActive(false);
        PanelCred.SetActive(false);
    }

    public void Voltar()
    {
        PanelInfo.SetActive(false);
        PanelCred.SetActive(false);
    }

    public void ShowInfo()
    {
        PanelInfo.SetActive(true);
    }

    public void ShowCred()
    {
        PanelCred.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
