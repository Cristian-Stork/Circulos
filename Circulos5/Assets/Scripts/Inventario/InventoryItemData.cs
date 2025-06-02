using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItemData", menuName = "InventoryItemData")]
public class InventoryItemData : ScriptableObject
{
    public string id;
    public string displayName;
    public Sprite icon;
    public GameObject prefab;
    public bool isTool;
    public bool isStackable;
    public DialogueObject collectedItemDialogue;
    public DialogueObject alreadyHasItemDialogue;
}
