using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private Image m_icon;
    [SerializeField] private TextMeshProUGUI m_label;
    [SerializeField] private GameObject m_stackObj;
    [SerializeField] private TextMeshProUGUI m_stackLabel;

    public InventoryItem itemSlot;

    [SerializeField] private GameObject frame;
    [SerializeField] private GameObject toolFrame;

    public void Set(InventoryItem item)
    {
        itemSlot = item;

        m_icon.sprite = item.data.icon;
        m_label.text = item.data.displayName;

        if (item.stackSize <= 1)
        {
            m_stackObj.SetActive(false);
            return;
        }

        m_stackLabel.text = item.stackSize.ToString();
    }

    private void OnMouseDown()
    {
        Debug.Log("Chamou OnMouseDown 1");

        if (itemSlot.data.isTool == true)
        {
            Debug.Log("Is tool");
            bool toolModoBool = Tool.instance.toolMode;
            Tool.instance.toolMode = !toolModoBool;
            TurnOffFrames();
            ToggleFrame(toolFrame);
            return;
        }

        if (Tool.instance != null && Tool.instance.toolMode == false)
        {
            CheckFrame();
            return;
        }

        GameObject frameOn = GameObject.Find("Frame");

        if (Tool.instance != null && Tool.instance.toolMode == true)
        {
            if (frame.activeSelf == true)
            {
                ToggleFrame(frame);
                Tool.instance.ClearSelectedItems();
                return;
            }

            Tool.instance.SelectItem(itemSlot.data);

            if (frameOn != null)
            {
                Tool.instance.Combine();
                return;
            }

            CheckFrame();
        }

        Debug.Log("Chamou OnMouseDown 2");
    }

    private void CheckFrame()
    {
        GameObject frameOn = GameObject.Find("Frame");

        TurnOffFrames();

        GameObject[] interactables = GameObject.FindGameObjectsWithTag("interaction");

        foreach (GameObject interactable in interactables)
        {
            Outline outline = interactable.GetComponent<Outline>();

            if (outline != null)
                outline.turnedOn = !frame.activeSelf;
        }

        ToggleFrame(frame);
    }

    private void ToggleFrame(GameObject frame)
    {
        frame.SetActive(!frame.activeSelf);
    }

    private void TurnOffFrames()
    {
        GameObject frame = GameObject.Find("Frame");

        if (frame != null)
        {
            frame.SetActive(false);
        }
    }
}
