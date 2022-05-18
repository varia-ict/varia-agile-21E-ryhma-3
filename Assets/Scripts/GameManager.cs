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
    private Button button;
    public AudioClip gameOverSound;
    public bool gameOver;
    

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        button = GetComponent<Button>();
        button.onClick.AddListener(SelectStartingMenu);
        startMenu.gameObject.SetActive(false);
    }

    void SelectStartingMenu()
    {
        Debug.Log(gameObject.name + " was clicked");
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

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    
}