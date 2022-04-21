using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void QuitButton()
    {
        Application.Quit();
        Debug.Log("You have clicked Quit Button");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Village_Scene");
    }
}
