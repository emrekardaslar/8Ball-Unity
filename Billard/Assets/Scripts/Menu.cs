using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("Billard");
    }

    public void QuitButton()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
