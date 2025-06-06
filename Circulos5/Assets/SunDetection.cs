using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SunDetection : InteractionStruct
{
    public static SunDetection instance;

    [SerializeField] private Vector2 direction;
    [SerializeField] private float distance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDirection(Vector2 target, Vector2 player)
    {
        direction = (target - player).normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("sun"))
        {
            Debug.Log("sun");

            Movement.instance.StopMoving();

            Vector2 position = transform.position;
            Vector2 target = position + -direction * distance;

            Interactions.instance.gameInteraction = this;
            Interactions.instance.target = target;
            Interactions.instance.StartInteraction(interactions, currentInteraction);
        }
    }
}
