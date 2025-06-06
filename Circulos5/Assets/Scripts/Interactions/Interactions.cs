using System;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    public static Interactions instance;

    public InteractionTypes[] currentInteractionType;

    private int interactionNumber;
    public int currentInteractionNumber;

    public InteractionStruct gameInteraction;

    [HideInInspector] public Vector2 target;

    private void Awake()
    {
        instance = this;
    }

    public void StartInteraction(InteractionTypes[] interactions, int currentInteraction)
    {
        Manager.instance.isInteracting = true;
        interactionNumber = 0;
        currentInteractionType = interactions;
        currentInteractionNumber = currentInteraction;
        Interact(interactions, currentInteraction);
    }

    public void Interact(InteractionTypes[] interactions, int currentInteraction)
    {
        if (interactionNumber == interactions[currentInteraction].interactions.Length)
        {
            if (currentInteraction + 1 != interactions.Length)
            {
                gameInteraction.currentInteraction++;
            }
            Manager.instance.isInteracting = false;

            gameInteraction = null;
            return;
        }

        interactionNumber++;

        switch (interactions[currentInteraction].interactions[interactionNumber - 1])
        {
            case interactionEnum.move:
                Manager.instance.Move(target);
                Debug.Log("É pra mover");
                break;

            case interactionEnum.collectItem:
                Manager.instance.CollectItem(interactions[currentInteraction].referenceItem);
                Debug.Log("É um item");
                break;

            case interactionEnum.removeItem:
                Manager.instance.RemoveItem(interactions[currentInteraction].itemRequirment);
                Debug.Log("Removeu item");
                break;

            case interactionEnum.dialogue:
                Manager.instance.Dialogue(interactions[currentInteraction].dialogueData);
                Debug.Log("É dialogo");
                break;

            case interactionEnum.changeSprite:
                SpriteRenderer sprite = gameInteraction.gameObject.GetComponent<SpriteRenderer>();
                Manager.instance.ChangeSprite(interactions[currentInteraction].newSprite, sprite);
                Debug.Log("Mudou sprite");
                break;

            case interactionEnum.turnOn:
                Manager.instance.TurnOnGameObject(interactions[currentInteraction].turnOnGameObject);
                Debug.Log("Ligou Game Object");
                break;

            case interactionEnum.toggleInteraction:
                Manager.instance.TurnOffInteraction();
                Debug.Log("Desligou interação");
                break;

            case interactionEnum.destroy:
                Manager.instance.DestroyGameObject(gameInteraction.gameObject);
                break;

            case interactionEnum.fadeIn:
                Manager.instance.FadeIn();
                Debug.Log("Fade in");
                break;

            case interactionEnum.fadeOut:
                Manager.instance.FadeOut();
                Debug.Log("Fade out");
                break;

            case interactionEnum.teleport:
                Manager.instance.Teleport(interactions[currentInteraction].teleportTransform, interactions[currentInteraction].newCamera);
                Debug.Log("Teleportou");
                break;

            case interactionEnum.nextScene:
                Manager.instance.NextScene(interactions[currentInteraction].nextScene);
                break;

            default:
                Debug.Log("Interação não encontrada");
                break;
        }
    }
}
