using UnityEngine;

public class Gambiarra : MonoBehaviour
{
    public static Gambiarra instance;

    public bool usouItem;
    public bool acertouSenha;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (usouItem && acertouSenha)
        {
            usouItem = false;
            acertouSenha = false;
            //GetComponent<Interactions>().StartInteraction();
        }
    }
}
