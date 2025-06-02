using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Cinemachine;

public class Manager : MonoBehaviour
{
    public static Manager instance;

    [SerializeField] private GameObject player;

    [SerializeField] private GameObject inventoryButton;
    [SerializeField] private GameObject kindleButton;

    [HideInInspector] public bool inventoryButtonPressed;

    public bool toggle = true;

    public bool isInteracting;

    private void Awake()
    {
        instance = this;
    }

    public void ToggleInteracting(bool toggleNew)
    {
        MouseInteraction.instance.enabled = toggleNew;

        GameObject[] chaos = GameObject.FindGameObjectsWithTag("chao");

        foreach (GameObject chao in chaos)
        {
            chao.GetComponent<Collider2D>().enabled = toggleNew;
        }

        if (inventoryButtonPressed == false)
        {
            inventoryButton.SetActive(toggleNew);
        }

        if (kindleButton != null)
            kindleButton.SetActive(toggleNew);

        GameObject[] interactables = GameObject.FindGameObjectsWithTag("interaction");

        foreach (GameObject interactable in interactables)
        {
            Outline outline = interactable.GetComponent<Outline>();

            if (outline != null)
                outline.turnedOn = toggleNew;
        }

        toggle = toggleNew;
    }

    public bool[] Check(bool[] requirements)
    {
        for (int i = 0; i < requirements.Length; i++)
        {
            if (requirements[i] == false)
            {
                requirements[i] = true;
                return requirements;
            }
        }

        return requirements;
    }

    public void LoopInteraction()
    {
        Interactions.instance.Interact(Interactions.instance.currentInteractionType, Interactions.instance.currentInteractionNumber);
    }

    public void Move(Transform targetPosition)
    {
        Movement.instance.SetTarget(targetPosition.position);
        Movement.instance.CheckMovement();
        Debug.Log("Chamou movement no manager");
    }

    public void CollectItem(InventoryItemData referenceItem)
    {
        if (referenceItem.isStackable == false && InventorySystem.instance.m_itemDictionary.TryGetValue(referenceItem, out InventoryItem value))
        {
            Dialogue(referenceItem.alreadyHasItemDialogue);
            return;
        }

        InventorySystem.instance.Add(referenceItem);

        if (referenceItem.collectedItemDialogue != null)
        {
            Dialogue(referenceItem.collectedItemDialogue);
            return;
        }

        LoopInteraction();
        Debug.Log("Chamou collect item no manager");
    }

    public void RemoveItem(InventoryItemData itemData)
    {
        InventorySystem.instance.Remove(itemData);
        Debug.Log("Chamou remove item no manager");

        LoopInteraction();
    }

    public void Dialogue(DialogueObject dialogueData)
    {
        DialougeManager.instance.StartDialogue(dialogueData);
        Debug.Log("Chamou dialouge no manager");
    }

    public void ChangeSprite(Sprite newSprite, SpriteRenderer sprite)
    {
        sprite.sprite = newSprite;
        Debug.Log("Chamou change sprite no manager");

        LoopInteraction();
    }

    public void TurnOnGameObject(GameObject gameObj)
    {
        gameObj.SetActive(true);
        Debug.Log("Chamou turn on no manager");

        LoopInteraction();
    }

    public void TurnOffInteraction()
    {
        toggle = !toggle;
        ToggleInteracting(toggle);
        Debug.Log("Chamou turn off no manager");

        LoopInteraction();
    }

    public void DestroyGameObject(GameObject gameObj)
    {
        isInteracting = false;
        Destroy(gameObj);
        Debug.Log("Chamou destroy no manager");
    }

    public void FadeIn()
    {
        Transition.instance.FadeIn();
        Debug.Log("Chamou fade in pelo manager");
    }

    public void FadeOut()
    {
        Transition.instance.FadeOut();
        Debug.Log("Chamou fade out pelo manager");
    }

    public void Teleport(Transform teleportTarget, CinemachineCamera newCam)
    {
        player.transform.position = teleportTarget.position;
        CameraSwitcher.instace.SwitchToCamera(newCam);

        LoopInteraction();
    }

    public void NextScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
