using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class DiarioManager : MonoBehaviour
{
    [Header("Game Objects do Diário")]
    public GameObject diarioPanel;
    public GameObject sumarioPanel;
    public GameObject paginaPanel;

    [Header("Textos do Diário")]
    public TextMeshProUGUI tituloPaginaText;
    public TextMeshProUGUI conteudoPaginaText;

    [Header("Buttons do Diário")]
    public Button proximoButton;
    public Button anteriorButton;
    public Button voltarAoSumarioButton;

    [Header("Conteúdos do Diário")]
    public List<string> titulosPaginas;
    [TextArea(1, 80)]
    public List<string> conteudosPaginas;

    private int paginaAtual = 0;

    public bool diarioAberto = false;

    [SerializeField] private UIInventory uiScript;

    void Start()
    {
        MostrarSumario();
    }

    public void MostrarSumario()
    {
        sumarioPanel.SetActive(true);
        paginaPanel.SetActive(false);
    }

    public void MostrarPagina(int indice)
    {
        if (indice >= 0 && indice < titulosPaginas.Count)
        {
            sumarioPanel.SetActive(false);
            paginaPanel.SetActive(true);

            tituloPaginaText.text = titulosPaginas[indice];
            conteudoPaginaText.text = conteudosPaginas[indice];
            paginaAtual = indice;
        }
    }

    public void ProximaPagina()
    {
        if (paginaAtual <= titulosPaginas.Count - 1)
        {
            MostrarPagina(paginaAtual + 1);
        }
    }

    public void PaginaAnterior()
    {
        if (paginaAtual >= 0)
        {
            MostrarPagina(paginaAtual - 1);
        }
    }

    public void AbrirFecharDiario()
    {
        Manager.instance.ToggleInteracting(diarioPanel.activeSelf);
        diarioPanel.SetActive(!diarioPanel.activeSelf);
        diarioAberto = !diarioAberto;
    }
}