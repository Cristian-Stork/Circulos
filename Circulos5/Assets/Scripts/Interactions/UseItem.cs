using UnityEngine;

public class UseItem : InteractionStruct
{
    public InventoryItemData itemRequirement;
    [SerializeField] private GameInteraction interactionCheck;

    private void OnMouseDown()
    {
        GameObject frame = GameObject.Find("Frame");

        if (frame != null)
        {
            GameObject frameParent = frame.transform.parent.gameObject;

            if (itemRequirement == frameParent.GetComponent<Slot>().itemSlot.data)
            {
                Interactions.instance.gameInteraction = this;
                Interactions.instance.StartInteraction(interactions, currentInteraction);
                UIInventory.instance.AccessInventory();
                Manager.instance.Check(interactionCheck.requirements);
            }

            else
            {
                Debug.Log("Não é o item correto");
            }
        }
    }
}
