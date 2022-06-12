using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Puzzle : MonoBehaviour
{
    public bool isCompleted { get; private set; }

    [SerializeField]
    private GameObject displayImage;
    [SerializeField]
    private GameObject slidePuzzle;

    void Update()
    {
        if (CompletePuzzle())
        {
            GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/@newSprites/slidePuzzle_hint");
            slidePuzzle.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/@newSprites/slidePuzzle_hint");
            DeleteChilds();
        }
        HideDisplay();
    }

    public void HideDisplay()
    {
        if(Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            this.gameObject.SetActive(false);
        }

        if(displayImage.GetComponent<DisplayImage>().CurrentState == DisplayImage.State.normal)
        {
            this.gameObject.SetActive(false);
        }
    }

    bool CompletePuzzle()
    {
        if (isCompleted) return true;

        isCompleted = true;

        var puzzlePieces = FindObjectsOfType<PuzzlePiece>();

        foreach(PuzzlePiece puzzlePiece in puzzlePieces)
        {
            if(!(int.Parse(puzzlePiece.gameObject.name.ToString().Substring(puzzlePiece.gameObject.name.Length - 1)) ==
                int.Parse(puzzlePiece.gameObject.GetComponent<Image>().sprite.name.ToString().Substring(puzzlePiece.gameObject.GetComponent<Image>().sprite.name.Length - 1))))
            {
                isCompleted = false;
            }
        }

        return isCompleted;
    }

    public void DeleteChilds()
    {

        var child = this.GetComponentsInChildren<Transform>();

        foreach (var iter in child)
        {
            if (iter != this.transform)
            {
                Destroy(iter.gameObject);
            }
        }
    }
}
