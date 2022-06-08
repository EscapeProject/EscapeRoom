using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberLock : MonoBehaviour
{
    public string Password;

    private Sprite[] numberSprites;

    public int[] currentIndividualindex = { 0, 0, 0, 0 };

    private void Start()
    {
        LoadAllNumberSprites();
    }
    private void LoadAllNumberSprites()
    {
        numberSprites = Resources.LoadAll<Sprite>("Sprites/numbers");
    }
}
