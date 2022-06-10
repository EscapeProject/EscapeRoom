using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chess : MonoBehaviour
{
    public GameObject ScreenPanel;
    public GameObject ObtainItem;

    private bool isCorrectPassword = false;

    public string CorrectPassword;

    private string inputPassword;

    void Start()
    {
        ObtainItem.SetActive(false);
        ScreenPanel.SetActive(false);
        this.gameObject.SetActive(false);
    }

    void Update()
    {
        VerifyPassword();
    }

    void VerifyPassword()
    {
        if (isCorrectPassword) return;

        if (Input.GetKey(KeyCode.Return))
        {
            inputPassword = ScreenPanel.transform.Find("Text").GetComponent<Text>().text;

            ScreenPanel.transform.Find("Text").GetComponent<Text>().text = "";

            if(inputPassword == CorrectPassword)
            {
                isCorrectPassword = true;
                Destroy(GameObject.Find("ScreenActivator"));
                Destroy(ScreenPanel);
                GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/chess_opened");
                ObtainItem.SetActive(true);
            }
        }
    }
}
