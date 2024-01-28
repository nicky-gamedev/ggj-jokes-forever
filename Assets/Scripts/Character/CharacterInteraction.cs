using System;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class CharacterInteraction : MonoBehaviour
{
    private CharacterController _characterController;
    
    private void OnEnable()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Item item = other.GetComponent<Item>();
        
        if (item != null)
        {
            ItemHandler(item);            
        }
    }

    private void ItemHandler(Item item)
    {
        switch (item)
        {
            case ICollectable collectableItem:
                CollectItem(collectableItem.Collect());
                break;
            case IInteractable interactableItem:
                interactableItem.Interact();
                break;
        }
    }

    private void CollectItem(Item item)
    {
        Debug.Log($"COLETEI O ITEM {item}");
    }
}
