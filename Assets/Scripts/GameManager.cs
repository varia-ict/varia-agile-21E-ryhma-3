using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject restartMenu;
    public AudioClip gameOverSound;
    public bool gameOver;
    public GameObject victoryScreen;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Restart game by reloading the scene
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // The game will end when the player's lives will end
    public void GameOver()
    {
        gameOver = true;
        AudioSource.PlayClipAtPoint(gameOverSound, transform.position);
        restartMenu.gameObject.SetActive(true);
    }

    public void NextLevel()//next level loads after the Player collects all the pickups
    {
        //if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("Level2"))
        //{
        //    victoryScreen.SetTrigger("Show");
        //}
        //else
        gameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BackToTheMainMenu()//return to the main menu
    {
        victoryScreen.gameObject.SetActive(false);
        SceneManager.LoadScene("StartMenu");
    }


}