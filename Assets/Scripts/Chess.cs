using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Chess : MonoBehaviour
{
    public GameObject ScreenPanel;
    public GameObject ObtainItem;

    private bool isCorrectPassword = false;
    [SerializeField]
    private GameObject displayImage;
    [SerializeField]
    private Text screenPanelText;
    [SerializeField]
    private GameObject SceneActivator;
    public string CorrectPassword;

    private string inputPassword;
    private bool isDestroyScreen;
    void Start()
    {
        isDestroyScreen = false;
        ObtainItem.SetActive(false);
        ScreenPanel.SetActive(false);
        this.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        if (!isDestroyScreen)
        {
            ScreenPanel?.SetActive(false);
        }
    }

    void Update()
    {
        VerifyPassword();
        HideDisplay();
    }

    void VerifyPassword()
    {
        if (isCorrectPassword) return;

        if (Input.GetKey(KeyCode.Return))
        {
            inputPassword = screenPanelText.text;

            screenPanelText.text = "";

            if(inputPassword == CorrectPassword)
            {
                isCorrectPassword = true;
                Destroy(SceneActivator);
                Destroy(ScreenPanel);
                isDestroyScreen = true;
                ObtainItem.SetActive(true);
            }
        }
    }

    void HideDisplay()
    {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            this.gameObject.SetActive(false);
        }

        if (displayImage.GetComponent<DisplayImage>().CurrentState == DisplayImage.State.normal)
        {
            this.gameObject.SetActive(false);
        }
    }

}
