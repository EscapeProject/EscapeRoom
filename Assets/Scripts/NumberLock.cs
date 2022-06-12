using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberLock : MonoBehaviour
{
    public string Password;

    public GameObject OpenLockerSprite;

    //[SerializeField]
    //private GameObject displayImage;
    [HideInInspector]
    public Sprite[] numberSprites;
    [HideInInspector]
    public int[] currentIndividualindex = { 0, 0, 0, 0 };

    private bool isOpen;

    private void Start()
    {
        OpenLockerSprite.SetActive(false);
        isOpen = false;
        LoadAllNumberSprites();
    }
    private void LoadAllNumberSprites()
    {
        numberSprites = Resources.LoadAll<Sprite>("Sprites/numbers");
    }
    private void Update()
    {
        OpenLocker();
        //LayerManage();
    }
    private bool VerifyCorrectCode()
    {
        bool correct = true;

        for(int i = 0; i < 4; i++)
        {
            if(Password[i] != transform.GetChild(i).GetComponent<SpriteRenderer>().sprite.name.Substring(transform.GetChild(i).GetComponent<SpriteRenderer>().sprite.name.Length - 1)[0])
            {
                correct = false;
            }
        }

        return correct;
    }

    private void OpenLocker()
    {
        if (isOpen) return;

        if (VerifyCorrectCode())
        {
            isOpen = true;
            OpenLockerSprite.SetActive(true);

            for(int i = 0; i < 4; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }

    //private void LayerManage()
    //{
    //    if (isOpen) return;

    //    if(displayImage.GetComponent<DisplayImage>().CurrentState == DisplayImage.State.normal)
    //    {
    //        foreach(Transform child in transform)
    //        {
    //            child.gameObject.layer = 2;
    //        }
    //    }
    //    else
    //    {
    //        foreach (Transform child in transform)
    //        {
    //            child.gameObject.layer = 0;
    //        }
    //    }
    //}
}
