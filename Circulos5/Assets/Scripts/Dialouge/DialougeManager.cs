using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialougeManager : MonoBehaviour
{
    public static DialougeManager instance;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public SpriteRenderer portraitSprite;

    public Animator animator;

    private Queue<DialogueData> sentences;

    public static bool IsDialogueActive = false;

    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {
        sentences = new Queue<DialogueData>();
    }

    public void StartDialogue(DialogueObject dialogueObj)
    {
        Manager.instance.ToggleInteracting(false);

        IsDialogueActive = true;

        animator.SetBool("IsOpen", true);

        sentences.Clear();

        foreach (DialogueData dialogue in dialogueObj.dialogueData)
        {
            sentences.Enqueue(dialogue);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueData dialogue = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(dialogue));
    }

    IEnumerator TypeSentence(DialogueData dialogue)
    {
        portraitSprite.sprite = dialogue.portrait;

        nameText.text = dialogue.name;
        dialogueText.text = "";
        string sentence = dialogue.dialogueText;

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        Manager.instance.ToggleInteracting(true);
        IsDialogueActive = false;
        animator.SetBool("IsOpen", false);

        Manager.instance.LoopInteraction();
    }
}
