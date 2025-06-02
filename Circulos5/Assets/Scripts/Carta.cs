using UnityEngine;

public class Carta : MonoBehaviour
{
    [SerializeField] private GameObject chao;

    public void SairCarta()
    {
        chao.SetActive(false);
        GetComponent<GameInteraction>().CheckRequirements();
        gameObject.SetActive(false);
    }
}
