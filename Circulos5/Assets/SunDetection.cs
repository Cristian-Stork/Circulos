using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SunDetection : InteractionStruct
{
    public static SunDetection instance;
    
    [SerializeField] private float distance;

    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("sun"))
        {
            Debug.Log("sun");

            Movement.instance.StopMoving();

            Vector2 position = transform.position;
            Vector2 target = position + -MouseInteraction.instance.direction * distance;

            Interactions.instance.gameInteraction = this;
            Interactions.instance.target = target;
            Interactions.instance.StartInteraction(interactions, currentInteraction);
        }
    }
}
