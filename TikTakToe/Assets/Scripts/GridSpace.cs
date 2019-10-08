using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

///<summary>
///Klasa reprezentujaca pole na planszy
///<summary>
public class GridSpace : MonoBehaviour
{
    public Button button;
    public TMP_Text buttonText;
    public string currentPlayer;

    private GameManager gameController;

    ///<summary>
    ///Metoda przydzielajaca kontroler w postaci klasy GameManager do 
    ///tej instancji klasy GridSpace.
    ///<param name="controller">Referencja zaleznosci instancji klasy GameManager</param>
    ///<summary>
    public void SetGameControllerReference(GameManager controller)
    {
        gameController = controller;
    }

    /// <summary>
    /// Metoda czyszczaca dane w polu zajmowanym przez GridSpace
    /// </summary>
    public void ResetSpace()
    {
        button.interactable = true;
        buttonText.text = "";
    }
    /// <summary>
    /// Metoda przydzielania danych w polu zajmowanym przez GridSpace
    /// </summary>
    public void SetSpace()
    {
        currentPlayer = gameController.GetPlayerSide();
        button.interactable = false;
        buttonText.text = currentPlayer;
        gameController.EndTurn();
    }
}
