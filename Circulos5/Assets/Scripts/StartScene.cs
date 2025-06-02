using System.Collections;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Manager.instance.ToggleInteracting(false);

        StartCoroutine(CallSound());
    }

    private IEnumerator CallSound()
    {
        yield return new WaitForSeconds(3);
        AudioManager.instance.PlaySFX("Drone");
        StartCoroutine(CallInteraction());
    }

    private IEnumerator CallInteraction()
    {
        yield return new WaitForSeconds(3);
        GetComponent<GameInteraction>().CheckRequirements();
    }
}
