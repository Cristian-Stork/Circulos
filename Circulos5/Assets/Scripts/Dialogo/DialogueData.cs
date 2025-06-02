using System;
using UnityEngine;

[Serializable]
public class DialogueData
{
    public string name;

    public Sprite portrait;

    [TextArea(3, 10)]
    public string dialogueText;
}
