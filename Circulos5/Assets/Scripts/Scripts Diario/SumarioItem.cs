using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SumarioItem : MonoBehaviour
{
    public DiarioManager diarioController;
    public int indicePagina;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(AoClique);
    }

    void AoClique()
    {
        diarioController.MostrarPagina(indicePagina);
    }
}