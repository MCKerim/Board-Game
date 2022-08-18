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
    [SerializeField] private TextMeshProUGUI currentStateText;

    private GameManagerState currentState;

    private ICard[,] playerCards = new ICard[2, 3];

    [SerializeField] private DestroyBuildingCard destroyBuildingCard;

    [SerializeField] private TextMeshProUGUI[] cardTexts;

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

        for(int i=0; i < 3; i++)
        {
            if(playerCards[currentPlayer - 1, i] == null)
            {
                playerCards[currentPlayer - 1, i] = destroyBuildingCard;
                cardTexts[(currentPlayer - 1) * 3 + i].SetText(destroyBuildingCard.GetDescription());
                NextPlayer();
                return;
            }
        }
    }

    public void UseCardButtonPressed(int cardIndex)
    {
        if (currentState != GameManagerState.Default)
        {
            return;
        }

        if (playerCards[currentPlayer - 1, cardIndex] == null)
        {
            return;
        }

        playerCards[currentPlayer - 1, cardIndex].Use();
        playerCards[currentPlayer - 1, cardIndex] = null;
        cardTexts[(currentPlayer - 1) * 3 + cardIndex].SetText("Empty");
    }

    public void ChangeState(GameManagerState state)
    {
        currentState = state;
        UpdateCurrentStateText();
    }

    private void UpdateCurrentStateText()
    {
        switch (currentState){
            case GameManagerState.Default:
                currentStateText.SetText("Build / Draw Card / Use Card");
                break;
            case GameManagerState.PlayerChooseBuildingToDestroy:
                currentStateText.SetText("Choose Building to Destroy");
                break;
        }
    }



    int buildingsPlaced = 0;
    public void FieldPressed(int x, int y)
    {
        if (currentState == GameManagerState.Default)
        {
            if (board.CheckIfFieldIsFree(x, y))
            {
                if (board.CheckIfFieldIsValidForPlayerToBuild(currentPlayer, x, y) || buildingsPlaced < 2)
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

            if (board.GetPlayerOfBuilding(x, y) == currentPlayer)
            {
                if (board.GetLevelOfBuilding(x, y) < 2)
                {
                    board.LevelUpBuilding(x, y);
                    NextPlayer();
                }
                return;
            }
        }
        else if(currentState == GameManagerState.PlayerChooseBuildingToDestroy)
        {
            if(!board.CheckIfFieldIsFree(x, y) && !board.CheckIfFieldIsObstacle(x, y) && board.GetPlayerOfBuilding(x, y) != currentPlayer)
            {
                board.DestroyBuilding(x, y);
                ChangeState(GameManagerState.Default);
                NextPlayer();
            }
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
