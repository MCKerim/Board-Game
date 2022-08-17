using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private Board board;
    private int currentPlayer;

    [SerializeField] private Color[] playerColors;

    [SerializeField] private TextMeshProUGUI currentPlayerText;

    private GameManagerState currentState;

    private Card[,] playerCards = new Card[2, 3];

    // Start is called before the first frame update
    void Start()
    {
        board = GameObject.FindObjectOfType<Board>();

        currentState = GameManagerState.Default;
        currentPlayer = 1;
        UpdateCurrentPlayerText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DrawCardButonPressed()
    {
        if (currentState != GameManagerState.Default)
        {
            return;
        }

        NextPlayer();
    }

    public void UseCardButtonPressed(int cardIndex)
    {
        if (currentState != GameManagerState.Default)
        {
            return;
        }

        playerCards[currentPlayer - 1, cardIndex].Use();
    }

    public void ChangeState(GameManagerState state)
    {
        currentState = state;
    }

    int buildingsPlaced = 0;
    public void FieldPressed(int x, int y)
    {
        if (currentState != GameManagerState.Default)
        {
            return;
        }

        if (board.CheckIfFieldIsFree(x, y))
        {
            if(board.CheckIfFieldIsValidForPlayerToBuild(currentPlayer, x, y) || buildingsPlaced < 2)
            {
                board.PlaceBuilding(false, currentPlayer, 0, x, y);
                NextPlayer();
                buildingsPlaced++;
            }
            return;
        }

        if (board.CheckIfFieldIsObstacle(x, y))
        {
            return;
        }

        if(board.GetPlayerOfBuilding(x, y) == currentPlayer)
        {
            if(board.GetLevelOfBuilding(x, y) < 2)
            {
                board.LevelUpBuilding(x, y);
                NextPlayer();
            }
            return;
        }
    }

    private void NextPlayer()
    {
        currentPlayer++;
        if(currentPlayer-1 >= playerColors.Length)
        {
            currentPlayer = 1;
        }

        UpdateCurrentPlayerText();
    }

    private void UpdateCurrentPlayerText()
    {
        currentPlayerText.SetText("Player " + currentPlayer);
        currentPlayerText.color = playerColors[currentPlayer - 1];
    }

}
