using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject[] buildingsPlayer1;
    [SerializeField] private GameObject[] buildingsPlayer2;

    private Board board;

    // Start is called before the first frame update
    void Start()
    {
        board = GameObject.FindObjectOfType<Board>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FieldPressed(int x, int y)
    {
        if (board.CheckIfFieldIsFree(x, y))
        {
            board.PlaceBuilding(buildingsPlayer1[2], x, y);
        }
        else
        {
            board.DestroyBuilding(x, y);
        }
    }

}
