using TMPro;
using UnityEngine;

public class GameInteraction : InteractionStruct
{
    public InteractionTypes[] interactions2;

    [Header("Verificações")]
    public bool[] requirements;

    public bool isSecondInteraction;

    public void CheckRequirements()
    {
        Interactions.instance.gameInteraction = this;
        Interactions.instance.target = targetPosition;

        if (requirements.Length == 0)
        {
            Interactions.instance.StartInteraction(interactions, currentInteraction);
            return;
        }

        for (int i = 0; i < requirements.Length; i++)
        {
            if (requirements[i] == false)
            {
                Interactions.instance.StartInteraction(interactions, currentInteraction);
                return;
            }
        }

        if (isSecondInteraction == false)
        {
            isSecondInteraction = true;
            currentInteraction = 0;
        }

        Interactions.instance.StartInteraction(interactions2, currentInteraction);
        return;
    }
}
