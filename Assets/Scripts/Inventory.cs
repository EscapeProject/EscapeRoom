using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private GameObject slots;
    [SerializeField]
    private GameObject m_itemdisplayer;
    public GameObject itemDisplayer => m_itemdisplayer;
    public GameObject currentSlot { get; set; }
    public GameObject previousSlot { get; set; }

    private void Start()
    {
        InitInventory();
    }
    private void Update()
    {
        SelectSlot();
        HideDisplay();
    }

    void InitInventory()
    {
        itemDisplayer.SetActive(false);
        foreach(Transform slot in slots.transform)
        {
            slot.transform.GetChild(0).GetComponent<Image>().sprite =
                Resources.Load<Sprite>("Inventory_items/empty_item");
            slot.GetComponent<Slot>().itemProperty = Slot.property.empty;
        }
        currentSlot = slots.transform.GetChild(7).gameObject;
        previousSlot = currentSlot;
    }

    public void SelectSlot()
    {
        foreach (Transform slot in slots.transform)
        {
            if(slot.gameObject == currentSlot && slot.GetComponent<Slot>().itemProperty == Slot.property.usable)
            {
                slot.GetComponent<Image>().color = new Color(.9f, .4f, .6f, 1);
            }
            else if (slot.gameObject == currentSlot && slot.GetComponent<Slot>().itemProperty == Slot.property.displayable)
            {
                slot.GetComponent<Slot>().DisplayItem();
            }
            else
            {
                slot.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
        }
    }
    public void HideDisplay()
    {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            itemDisplayer.SetActive(false);
            if(currentSlot.GetComponent<Slot>().itemProperty == Slot.property.displayable)
            {
                currentSlot = previousSlot;
                previousSlot = currentSlot;
            }
        }
    }
}
