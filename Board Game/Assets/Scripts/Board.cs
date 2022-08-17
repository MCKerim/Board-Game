using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    private Building[,] board = new Building[5, 5];
    [SerializeField] private Building building;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    public bool CheckIfFieldIsObstacle(int x, int y)
    {
        return board[x, y].IsObstacle();
    }

    public bool CheckIfFieldIsFree(int x, int y)
    {
        return board[x, y] == null;
    }

    public int GetPlayerOfBuilding(int x, int y)
    {
        return board[x, y].GetPlayer();
    }

    public int GetLevelOfBuilding(int x, int y)
    {
        return board[x, y].GetLevel();
    }

    public bool CheckIfFieldIsValidForPlayerToBuild(int player, int x, int y)
    {
        //Check if left Building is from player
        if(x != 0 && board[x - 1, y] != null && board[x - 1, y].GetPlayer() == player)
        {
            return true;
        }

        //Check if right Building is from player
        if (x != board.GetLength(0) - 1 && board[x + 1, y] != null && board[x + 1, y].GetPlayer() == player)
        {
            return true;
        }

        //Check if bottom Building is from player
        if (y != 0 && board[x, y - 1] != null && board[x, y - 1].GetPlayer() == player)
        {
            return true;
        }

        //Check if top Building is from player
        if (y != board.GetLength(1) - 1 && board[x, y + 1] != null && board[x, y + 1].GetPlayer() == player)
        {
            return true;
        }

        //Check if left bottom Building is from player
        if (x != 0 && y != 0 && board[x - 1, y - 1] != null && board[x - 1, y - 1].GetPlayer() == player)
        {
            return true;
        }

        //Check if right top Building is from player
        if (x != board.GetLength(0) - 1 && y != board.GetLength(1) - 1 && board[x + 1, y + 1] != null && board[x + 1, y + 1].GetPlayer() == player)
        {
            return true;
        }

        //Check if left top Building is from player
        if (x != 0 && y != board.GetLength(1) - 1 && board[x - 1, y + 1] != null && board[x - 1, y + 1].GetPlayer() == player)
        {
            return true;
        }

        //Check if right Bottom Building is from player
        if (x != board.GetLength(0) - 1 && y != 0 && board[x + 1, y - 1] != null && board[x + 1, y - 1].GetPlayer() == player)
        {
            return true;
        }

        return false;
    }

    public void PlaceBuilding(bool isObstacle, int player, int level, int x, int y)
    {
        Building placedBuilding = Instantiate(building, transform);
        placedBuilding.Make(isObstacle, player, level);

        placedBuilding.transform.position = new Vector3(x * 1.1f, 0, y * 1.1f);
        board[x, y] = placedBuilding;
    }

    public void DestroyBuilding(int x, int y)
    {
        Destroy(board[x, y].gameObject);
        board[x, y] = null;
    }

    public void LevelUpBuilding(int x, int y)
    {
        board[x, y].LevelUp();
    }
}
