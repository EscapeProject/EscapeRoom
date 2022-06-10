using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{

    public GameObject[] ScaleBoxes;
    public int[] Weight = new int[5];

    public GameObject ScaleDisplayer;

    private GameObject displayImage;
    private Block[] blocks;

    public bool isSolved { get; private set; }

    private void Start()
    {
        isSolved = false;
        displayImage = GameObject.Find("displayImage");
        blocks = FindObjectsOfType<Block>();
    }

    private void Update()
    {
        Display();

        if (VerifySolution() && !isSolved)
        {
            isSolved = true;

            ScaleDisplayer.GetComponent<ChangeView>().SpriteName = "scaleopen";

            displayImage.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/scale open");
        }
    }

    private void Display()
    {
        if (displayImage.GetComponent<SpriteRenderer>().sprite.name == "scale" || displayImage.GetComponent<SpriteRenderer>().sprite.name == "scale open")
        {
            for (int i = 0; i < blocks.Length; i++)
            {
                blocks[i].gameObject.SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < blocks.Length; i++)
            {
                blocks[i].gameObject.SetActive(false);
            }
        }
    }

    private bool VerifySolution()
    {
        bool solved = true;

        for (int i = 0; i < ScaleBoxes.Length; i++)
        {
            if (blocks[i].indexOfBox != blocks[i].correctBoxIndex)
                solved = false;
        }

        return solved;
    }
}
