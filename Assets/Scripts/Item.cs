using System.Collections;
using System.Collections.Generic;
using Interactable;
using UnityEngine;

public class Item : InteractableObject
{
    [SerializeField] private InspectableCamera inspectableCamera;
    public override void Interact()
    {
        inspectableCamera.Inspect(gameObject);
        DoAction();
    }
}
