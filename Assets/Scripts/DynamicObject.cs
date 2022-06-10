using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicObject : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject inventory;

    public string UnlockItem;

    public GameObject ChangedStateSprite;

    public enum InteractionProperty { simple_interaction, access_interaction}
    public InteractionProperty Property;
    public GameObject AccessObject;
    

    private void Start()
    {
        ChangedStateSprite.SetActive(false);
        AccessObject.SetActive(false);
    }


    public void Interact(DisplayImage currentDisplay)
    {
        if (inventory.GetComponent<Inventory>().currentSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem || UnlockItem == "")
        {
            ChangedStateSprite.SetActive(true);
            this.gameObject.layer = 2;

            if (Property == InteractionProperty.simple_interaction) return;
            inventory.GetComponent<Inventory>().currentSlot.GetComponent<Slot>().ClearSlots();
            AccessObject.SetActive(true);

        }

    }
}
