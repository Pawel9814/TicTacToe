using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GridSpace : MonoBehaviour
{
    public Button button;
    public TMP_Text buttonText;
    public string currentPlayer;

    private GameManager gameController;

    public void SetGameControllerReference(GameManager controller)
    {
        gameController = controller;
    }

    public void ResetSpace()
    {
        button.interactable = true;
        buttonText.text = "";
    }
    public void SetSpace()
    {
        currentPlayer = gameController.GetPlayerSide();
        button.interactable = false;
        buttonText.text = currentPlayer;
        gameController.EndTurn();
    }
}
