using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public enum InteractionType
    {
        Click
    }

    [SerializeField] protected BoxCollider physicalCollider;
    [SerializeField] protected BoxCollider triggerCollider;
    [SerializeField] protected controlPersonaje player;
    protected InteractionType interactionType;
    public bool hasInteracted;

    ////////////Abstract methods////////////
    public abstract string GetDescription();
    public abstract void Interact();
    ////////////////////////////////////////
    

    /////////////Regular methods////////////
    public InteractionType GetInteractionType()
    {
        return interactionType;
    }

    public BoxCollider GetPhysicalCollider()
    {
        return physicalCollider;
    }
    public BoxCollider GetTriggerCollider()
    {
        return triggerCollider;
    }
    ////////////////////////////////////////
}
