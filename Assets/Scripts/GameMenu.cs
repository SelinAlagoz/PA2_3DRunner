using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    public GameObject StartMenu;
    public GameManager gameManager;
    public PlayerMotor playerMotor;

    public void playGame()
    {
        GameManager.GameStarted = true;
        playerMotor.SetCanMove(true);
        StartMenu.SetActive(false);
        gameManager.StartGame();
    }

    public void quitGame()
    {
        Debug.Log("Quit!!!");
        Application.Quit();
    }
}