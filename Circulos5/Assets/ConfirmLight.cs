using UnityEngine;

public class ConfirmLight : MonoBehaviour
{
    public void Signal()
    {
        KeypadManager keypad = GameObject.Find("KeypadManager").GetComponent<KeypadManager>();

        keypad.AcertouSenha();
    }
}
