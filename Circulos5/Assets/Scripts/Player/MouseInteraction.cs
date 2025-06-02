using UnityEngine;

public class MouseInteraction : MonoBehaviour
{
    public static MouseInteraction instance;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 mousePosition = Input.mousePosition;
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 0)), Vector3.forward, 100);

            if (hit.collider != null)
            {
                if (hit.collider.tag == "chao")
                {
                    Manager.instance.isInteracting = false;
                    Vector3 targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 0));
                    Movement.instance.SetTarget(targetPosition);
                    Movement.instance.CheckMovement();
                }

                if (hit.collider.tag == "interaction" && Manager.instance.isInteracting == false)
                {
                    hit.collider.gameObject.GetComponent<GameInteraction>().CheckRequirements();
                }
            }
        }
    }
}
