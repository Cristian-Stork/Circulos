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
}
