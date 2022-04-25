using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameActive;
    public GameObject startingMenu;
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        button = GetComponent<Button>();
        button.onClick.AddListener(SelectStartingMenu);
        startingMenu.gameObject.SetActive(false);

    }

    void SelectStartingMenu()
    {
        Debug.Log(gameObject.name + " was clicked");
    }

    // Restart game by reloading the scene
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



    // Update is called once per frame
    void Update()
    {

    }
}