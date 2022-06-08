using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerNumber : MonoBehaviour, IInteractable
{

    

    public void Interact(DisplayImage currentDisplay)
    {
        transform.parent.GetComponent<NumberLock>().currentIndividualindex[transform.GetSiblingIndex()]++;

        if (transform.parent.GetComponent<NumberLock>().currentIndividualindex[transform.GetSiblingIndex()] > 9)
            transform.parent.GetComponent<NumberLock>().currentIndividualindex[transform.GetSiblingIndex()] = 0;

        this.gameObject.GetComponent<SpriteRenderer>().sprite = transform.parent.GetComponent<NumberLock>().numberSprites[transform.parent.GetComponent<NumberLock>().currentIndividualindex[transform.GetSiblingIndex()]];
    }
}