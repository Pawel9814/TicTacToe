using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


/// <summary>
/// Klasa kontroler dla gry. Klasa zarzadza instancjami klasy GridSpace
/// </summary>
public class GameManager : MonoBehaviour
{
    public GridSpace[] spacesList;
    private string playerSide;

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] TMP_Text gameOverText;
    int moveCount = 0;

    /// <summary>
    /// Metoda wywolywana przy pierwszym tworzeniu klasy
    /// </summary>
    void Awake()
    {
        gameOverPanel.SetActive(false);
        SetGameControllerReferenceOnButtons();
        playerSide = "X";
        moveCount = 0;
    }

    /// <summary>
    /// Przydziela referencje klasy GameManager do pol z klas GridSpace
    /// </summary>
    void SetGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < spacesList.Length; i++)
        {
            spacesList[i].SetGameControllerReference(this);

        }
    }

    /// <summary>
    /// Czysci plansze 
    /// </summary>
    public void ResetGame()
    {
        moveCount = 0;
        playerSide = "X";
        for (int i = 0; i < spacesList.Length; i++)
        {
            spacesList[i].ResetSpace();
        }
        gameOverPanel.SetActive(false);
    }

    /// <summary>
    /// metoda do walidacji aktualnie wykonujacego ruch gracza
    /// </summary>
    /// <returns>zwraca aktualnego gracza</returns>
    public string GetPlayerSide()
    {
        return playerSide;
    }

    /// <summary>
    /// Konczy ture aktualnego gracza
    /// </summary>
    public void EndTurn()
    {
        moveCount++;
        for (int i = 0; i < 7; i+=3)
        {
            if (spacesList[i].buttonText.text == playerSide && spacesList[i+1].buttonText.text == playerSide && spacesList[i+2].buttonText.text == playerSide)
            {
                GameOver();
                return;
            }
        }

        for (int i = 0; i < 3; i++)
        {
            if (spacesList[i].buttonText.text == playerSide && spacesList[i + 3].buttonText.text == playerSide && spacesList[i + 6].buttonText.text == playerSide)
            {
                GameOver();
                return;
            }
        }

        if (spacesList[0].buttonText.text == playerSide && spacesList[4].buttonText.text == playerSide && spacesList[8].buttonText.text == playerSide)
        {
            GameOver();
            return;
        }
        if (spacesList[2].buttonText.text == playerSide && spacesList[4].buttonText.text == playerSide && spacesList[6].buttonText.text == playerSide)
        {
            GameOver();
            return;
        }

        if (moveCount >= 9)
        {
            GameOverPanelTog("Mamy Remis");
        }

        ChangeSides();
    }
    /// <summary>
    /// Zmienia przeciwnika
    /// </summary>
    void ChangeSides()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
    }

    /// <summary>
    /// Konczy rozgrywke
    /// </summary>
    void GameOver()
    {
        for (int i = 0; i < spacesList.Length; i++)
        {
            spacesList[i].button.interactable = false;
        }

        GameOverPanelTog(playerSide + " Wygrywa!");
    }
    /// <summary>
    /// Wyswietla komunikat po zakonczeniu gry
    /// </summary>
    /// <param name="msg">komunikat do wyswietlenia</param>
    void GameOverPanelTog(string msg)
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = msg;
    }
}
