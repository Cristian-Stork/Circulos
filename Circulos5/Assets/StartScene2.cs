using UnityEngine;

public class StartScene2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<GameInteraction>().CheckRequirements();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
