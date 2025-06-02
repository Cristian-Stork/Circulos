using System.Collections;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public static Transition instance;

    private SpriteRenderer spriteRenderer;

    [SerializeField] private float fadeSpeed;

    private void Awake()
    {
        instance = this;

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void FadeIn()
    {
        StartCoroutine(FadeInCoroutine());
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutCoroutine());
    }

    private IEnumerator FadeInCoroutine()
    {
        while (spriteRenderer.color.a < 1)
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, spriteRenderer.color.a + fadeSpeed);

            yield return null;
        }

        Manager.instance.LoopInteraction();
    }

    private IEnumerator FadeOutCoroutine()
    {
        yield return new WaitForSeconds(3);

        while (spriteRenderer.color.a > 0.0001)
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, spriteRenderer.color.a - fadeSpeed);

            yield return null;
        }

        Manager.instance.LoopInteraction();
    }
}
