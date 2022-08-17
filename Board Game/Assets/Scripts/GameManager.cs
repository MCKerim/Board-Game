using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private Board board;
    private int currentPlayer;

    [SerializeField] private TextMeshProUGUI currentPlayerText;

    // Start is called before the first frame update
    void Start()
    {
        board = GameObject.FindObjectOfType<Board>();

        currentPlayer = 1;
        currentPlayerText.SetText("Player " + currentPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int buildingsPlaced = 0;

    public void FieldPressed(int x, int y)
    {
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
        if(currentPlayer == 1)
        {
            currentPlayer = 2;
        }
        else if(currentPlayer == 2)
        {
            currentPlayer = 1;
        }

        currentPlayerText.SetText("Player " + currentPlayer);
    }

}
