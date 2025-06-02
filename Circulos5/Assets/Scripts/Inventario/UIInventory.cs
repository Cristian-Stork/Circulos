using System;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    public static UIInventory instance;

    [SerializeField] private GameObject m_slotPrefab;
    public bool inventoryActive;

    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void OnUpdateInventory()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }

        DrawInventory();
    }

    public void DrawInventory()
    {
        foreach (InventoryItem item in InventorySystem.instance.inventory)
        {
            AddInventorySlot(item);
        }
    }

    public void AddInventorySlot(InventoryItem item)
    {
        GameObject obj = Instantiate(m_slotPrefab);
        obj.transform.SetParent(transform, false);

        Slot slot = obj.GetComponent<Slot>();
        slot.Set(item);
    }

    public void AccessInventory()
    {
        if (inventoryActive == false)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition += new Vector2(-100, 0);
            Manager.instance.inventoryButtonPressed = true;
            Manager.instance.ToggleInteracting(inventoryActive);
            Movement.instance.StopMoving();
        }

        else
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition += new Vector2(100, 0);

            if (Tool.instance != null)
            {
                Tool.instance.TurnOffAllFrames();
                Tool.instance.ClearSelectedItems();
                Tool.instance.toolMode = false;
            }

            Manager.instance.ToggleInteracting(inventoryActive);
            Manager.instance.inventoryButtonPressed = false;
        }

        inventoryActive = !inventoryActive;
    }
}
