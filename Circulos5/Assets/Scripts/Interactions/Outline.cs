using UnityEngine;

public class Outline : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Material materialInstance;

    [HideInInspector] public bool turnedOn;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        //copia do material
        materialInstance = new Material(spriteRenderer.material);
        spriteRenderer.material = materialInstance;

        turnedOn = true;

        SetOutlineEnabled(false);
    }

    private void OnMouseEnter()
    {
        if (turnedOn)
        {
            SetOutlineEnabled(true);
        }
    }

    private void OnMouseExit()
    {
        if (turnedOn)
        {
            SetOutlineEnabled(false);
        }
    }

    private void SetOutlineEnabled(bool enabled)
    {
        if (materialInstance != null)
        {
            materialInstance.SetInt("_OutlineEnabled", enabled ? 1 : 0);
        }
    }
}
