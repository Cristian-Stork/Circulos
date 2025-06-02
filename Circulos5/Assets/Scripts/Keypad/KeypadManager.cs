using TMPro;
using UnityEngine;

public class KeypadManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI displayText;
    [SerializeField] private string correctPassword;

    [SerializeField] private GameObject panel;

    [SerializeField] private GameInteraction interactionCheck;

    private bool solvedPassword;

    private void Start()
    {
        displayText.text = "";
    }

    public void ButtonClicked(int num)
    {
        if (solvedPassword)
            return;

        if (displayText.text.Length == correctPassword.Length)
        {
            Debug.Log("Sem espaço para mais números");
        }

        else
        {
            if (displayText.text == "")
            {
                displayText.text += num;
            }

            else
            {
                displayText.text += "-" + num;
            }

            Debug.Log("O botão clicado foi o " + num);
        }
    }

    public void EraseNumber()
    {
        if (solvedPassword)
            return;

        int length = displayText.text.Length;

        if (length == 1)
        {
            displayText.text = "";
        }

        else
        {
            displayText.text = displayText.text.Remove(length - 2);
        }
    }

    public void ConfirmPassword()
    {
        if (solvedPassword)
            return;

        if (displayText.text == correctPassword)
        {
            if (interactionCheck != null)
                Manager.instance.Check(interactionCheck.requirements);

            Manager.instance.ToggleInteracting(true);
            panel.SetActive(false);
            solvedPassword = true;
            Debug.Log("Senha correta");

            GameInteraction interaction = GetComponent<GameInteraction>();

            if (interaction != null)
            {
                GetComponent<GameInteraction>().CheckRequirements();
            }
        }

        else
        {
            displayText.text = "";
            Debug.Log("Senha errada");
        }
    }

    public void Voltar()
    {
        Manager.instance.ToggleInteracting(true);
        panel.SetActive(false);
    }
}
