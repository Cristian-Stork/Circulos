using System;
using UnityEngine;

[Serializable]
public struct ItemCombinations
{
    public InventoryItemData item1;
    public InventoryItemData item2;
    public InventoryItemData itemResult;
    public DialogueObject dialogueResult;
}

public class Tool : MonoBehaviour
{
    public static Tool instance;

    public bool toolMode;

    public ItemCombinations[] itemCombinations;
    public InventoryItemData[] selectedItems = new InventoryItemData[2];

    [SerializeField] private DialogueObject dialogueFail;

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

    public void SelectItem(InventoryItemData item)
    {
        for (int i = 0; i < selectedItems.Length; i++)
        {
            if (selectedItems[i] == null)
            {
                selectedItems[i] = item;
                return;
            }
        }
    }

    public void Combine()
    {
        Debug.Log("Combine");

        for (int i = 0; i < itemCombinations.Length; i++)
        {
            if (selectedItems[0] == itemCombinations[i].item1)
            {
                if (selectedItems[1] == itemCombinations[i].item2)
                {
                    Debug.Log("Combinação encontrada");
                    ReplaceItems(i);
                    DialougeManager.instance.StartDialogue(itemCombinations[i].dialogueResult);
                    return;
                }
            }

            else if (selectedItems[0] == itemCombinations[i].item2)
            {
                if (selectedItems[1] == itemCombinations[i].item1)
                {
                    Debug.Log("Combinação encontrada");
                    DialougeManager.instance.StartDialogue(itemCombinations[i].dialogueResult);
                    ReplaceItems(i);
                    return;
                }
            }
        }

        for (int i = 0 ;i < selectedItems.Length; i++)
        {
            if (selectedItems[i].id == "InventoryItemData_Adubo_Combinado")
            {
                //Add(Adubo_ruim);
                return;
            }
        }

        Debug.Log("Combinação não encontrada");
        UIInventory.instance.AccessInventory();
        toolMode = false;
        DialougeManager.instance.StartDialogue(dialogueFail);
    }

    private void ReplaceItems(int itemCombination)
    {
        toolMode = false;
        InventorySystem.instance.Remove(selectedItems[0]);
        InventorySystem.instance.Remove(selectedItems[1]);
        InventorySystem.instance.Add(itemCombinations[itemCombination].itemResult);
        UIInventory.instance.AccessInventory();
    }

    public void ClearSelectedItems()
    {
        selectedItems[0] = null;
        selectedItems[1] = null;
    }

    public void TurnOffAllFrames()
    {
        GameObject frame = GameObject.Find("Frame");

        if (frame != null)
            frame.SetActive(false);

        GameObject toolFrame = GameObject.Find("ToolFrame");

        if (toolFrame != null)
            toolFrame.SetActive(false);
    }
}
