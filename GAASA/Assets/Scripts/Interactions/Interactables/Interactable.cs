using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public enum InteractionType
    {
        Click
    }

    protected InteractionType interactionType;
    public bool hasInteracted;

    public abstract string GetDescription();
    public abstract InteractionType GetInteractionType();
    public abstract void Interact();
}
