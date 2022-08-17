using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    private GameObject[,] board = new GameObject[5, 5];
    
    // Start is called before the first frame update
    void Start()
    {

    }

    public bool CheckIfFieldIsFree(int x, int y)
    {
        return board[x, y] == null;
    }

    public void PlaceBuilding(GameObject building, int x, int y)
    {
        GameObject placedBuilding = Instantiate(building, transform);
        placedBuilding.transform.position = new Vector3(x * 1.1f, 0, y * 1.1f);
        board[x, y] = placedBuilding;
    }

    public void DestroyBuilding(int x, int y)
    {
        Destroy(board[x, y]);
        board[x, y] = null;
    }
}
