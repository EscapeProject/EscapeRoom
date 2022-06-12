using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeView : MonoBehaviour, IInteractable
{
    public string SpriteName;

    private float initialCameraSize;
    private Vector3 initialCameraposition;

    private void Start()
    {
        initialCameraSize = Camera.main.orthographicSize;
        initialCameraposition = Camera.main.transform.position;
    }

    public void Interact(DisplayImage currentDisplay)
    {
        if (this.gameObject.name == "Gameclear")
        {
            SceneManager.LoadScene(1);
            return;
        }

        currentDisplay.GetComponent<SpriteRenderer>().sprite =
            Resources.Load<Sprite>("Sprites/@newSprites/" + SpriteName);
        
        currentDisplay.CurrentState = DisplayImage.State.ChangedView;

        Camera.main.orthographicSize = initialCameraSize;
        Camera.main.transform.position = initialCameraposition;
    }
}
