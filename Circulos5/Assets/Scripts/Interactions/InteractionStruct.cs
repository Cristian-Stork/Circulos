using System;
using Unity.Cinemachine;
using UnityEngine;

public enum interactionEnum
{
    move,
    collectItem,
    removeItem,
    dialogue,
    changeSprite,
    turnOn,
    turnOff,
    toggleInteraction,
    destroy,
    fadeIn,
    fadeOut,
    teleport,
    nextScene
};

[Serializable]
public struct InteractionTypes
{
    public InventoryItemData referenceItem;
    public InventoryItemData itemRequirment;
    public DialogueObject dialogueData;
    public Sprite newSprite;
    public GameObject turnOnGameObject;
    public GameObject turnOffGameObject;
    public Transform teleportTransform;
    public CinemachineCamera newCamera;
    public int nextScene;

    public interactionEnum[] interactions;
}

public class InteractionStruct : MonoBehaviour
{
    public int currentInteraction;

    [Header("Lista de Interações")]
    public InteractionTypes[] interactions;

    [HideInInspector] public Vector2 targetPosition;

    private void Start()
    {
        Transform targetTransform = transform.Find("Target");
        
        if (targetTransform != null)
        {
            Vector2 target = targetTransform.position;
            targetPosition = target;
        }
    }
}
