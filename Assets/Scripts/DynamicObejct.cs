using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicObejct : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject inventory;

    public string UnlockItem;

    public GameObject ChangedStateSprite;

    

    private void Start()
    {
        ChangedStateSprite.SetActive(false);
    }


    public void Interact(DisplayImage currentDisplay)
    {
        if (inventory.GetComponent<Inventory>().currentSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem || UnlockItem == "")
        {
            ChangedStateSprite.SetActive(true);
            inventory.GetComponent<Inventory>().currentSlot.GetComponent<Slot>().ClearSlots();
        }
    }
}
