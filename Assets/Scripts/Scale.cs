using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    [SerializeField]
    private GameObject displayImage;
    public GameObject[] ScaleBoxes;

    public GameObject ScaleDisplayer;
    public GameObject cleargift;

    [SerializeField]
    private Block[] blocks;

    public bool isSolved { get; private set; }

    private void Start()
    {
        isSolved = false;
        ScaleDisplayer.SetActive(false);
        cleargift.SetActive(false);
    }

    private void Update()
    {
        Display();

        if (VerifySolution() && !isSolved)
        {
            isSolved = true;
            ScaleDisplayer.SetActive(true);
            cleargift.SetActive(true);
        }
    }

    private void Display()
    {
        if (displayImage.GetComponent<SpriteRenderer>().sprite.name == "wall1_jigsaw")
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
