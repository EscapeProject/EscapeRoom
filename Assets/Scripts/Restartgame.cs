using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restartgame : MonoBehaviour
{
    public void OnClickButton()
    {
        SceneManager.LoadScene(0);
    }
}
