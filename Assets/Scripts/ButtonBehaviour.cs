using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
    public enum ButtonId
    {
        roomChangeButton, returnButton
    }

    public ButtonId ThisButtonId;

    [SerializeField]
    private DisplayImage currentDisplay;

    void Update()
    {
        HideDisplay();
        Display();
    }
    void HideDisplay()
    {
        if(currentDisplay.CurrentState == DisplayImage.State.normal && ThisButtonId == ButtonId.returnButton)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                GetComponent<Image>().color.b, 0);
            GetComponent<Button>().enabled = false;
            this.transform.SetSiblingIndex(0);
        }

        if (!(currentDisplay.CurrentState == DisplayImage.State.normal) && ThisButtonId == ButtonId.roomChangeButton)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                GetComponent<Image>().color.b, 0);
            GetComponent<Button>().enabled = false;
            this.transform.SetSiblingIndex(0);
        }
    }

    void Display()
    {
        if (!(currentDisplay.CurrentState == DisplayImage.State.normal) && ThisButtonId == ButtonId.returnButton)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                GetComponent<Image>().color.b, 1);
            GetComponent<Button>().enabled = true;
        }

        if (currentDisplay.CurrentState == DisplayImage.State.normal && ThisButtonId == ButtonId.roomChangeButton)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                GetComponent<Image>().color.b, 1);
            GetComponent<Button>().enabled = true;
        }
    }
}
